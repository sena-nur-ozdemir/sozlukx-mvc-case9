using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
namespace BusinessLayer.Concrete
{
    public class MessageManager
    {
        private readonly IMessageDal _messages;
        private readonly IWriterDal _writers;
        public MessageManager(IMessageDal messages, IWriterDal writers) { _messages = messages; _writers = writers; }
        private Writer Writer(int id)
        { var w = _writers.GetByID(id); if (w == null || !w.WriterStatus) throw new UnauthorizedAccessException("Aktif yazar hesabı gerekli."); return w; }
        public List<Message> Inbox(int id) { var mail = Writer(id).WriterMail.ToLowerInvariant(); return _messages.List(m => m.ReceiverMail.ToLower() == mail && !m.IsDraft).OrderByDescending(m => m.MessageDate).ToList(); }
        public List<Message> Sent(int id) { var mail = Writer(id).WriterMail.ToLowerInvariant(); return _messages.List(m => m.SenderMail.ToLower() == mail && !m.IsDraft).OrderByDescending(m => m.MessageDate).ToList(); }
        public List<Message> Drafts(int id) { var mail = Writer(id).WriterMail.ToLowerInvariant(); return _messages.List(m => m.SenderMail.ToLower() == mail && m.IsDraft).OrderByDescending(m => m.MessageDate).ToList(); }
        public void Compose(int id, string recipient, string subject, string body, bool draft)
        {
            var sender = Writer(id);
            recipient = (recipient ?? "").Trim(); subject = (subject ?? "").Trim(); body = (body ?? "").Trim();
            if (subject.Length < 2 || subject.Length > 150 || body.Length < 2 || body.Length > 5000) throw new ArgumentException("Konu 2–150, mesaj 2–5000 karakter olmalıdır.");
            if (recipient.Length < 5 || recipient.Length > 100) throw new ArgumentException("Alıcı e-posta adresi gerekli.");
            var key = recipient.ToLowerInvariant();
            var target = _writers.Get(x => x.WriterMail.ToLower() == key && x.WriterStatus);
            if (target == null) throw new ArgumentException("Bu e-postada aktif bir yazar bulunamadı.");
            _messages.Insert(new Message { SenderMail = sender.WriterMail, ReceiverMail = target.WriterMail, Subject = subject, MessageContent = body, MessageDate = DateTime.Now, IsRead = false, IsDraft = draft });
        }
        public Message Read(int writerId, int id)
        {
            var me = Writer(writerId); var m = _messages.GetByID(id);
            if (m == null) return null;
            bool receiver = string.Equals(me.WriterMail, m.ReceiverMail, StringComparison.OrdinalIgnoreCase);
            bool sender = string.Equals(me.WriterMail, m.SenderMail, StringComparison.OrdinalIgnoreCase);
            if ((!receiver && !sender) || (m.IsDraft && !sender)) throw new UnauthorizedAccessException("Mesaj sana ait değil.");
            if (receiver && !m.IsDraft && !m.IsRead) { m.IsRead = true; _messages.Update(m); }
            return m;
        }
        public void SendDraft(int writerId, int id)
        {
            var me = Writer(writerId); var m = _messages.GetByID(id);
            if (m == null) throw new InvalidOperationException("Taslak bulunamadı.");
            if (!m.IsDraft || !string.Equals(me.WriterMail, m.SenderMail, StringComparison.OrdinalIgnoreCase)) throw new UnauthorizedAccessException("Taslak sana ait değil.");
            var to = m.ReceiverMail.ToLowerInvariant();
            if (!_writers.List(w => w.WriterMail.ToLower() == to && w.WriterStatus).Any()) throw new ArgumentException("Alıcı hesabı artık aktif değil.");
            m.IsDraft = false; m.MessageDate = DateTime.Now; _messages.Update(m);
        }
    }
}