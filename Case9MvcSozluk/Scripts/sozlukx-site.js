/* ══════════════ MOCK DATA ══════════════ */
const AVATAR_COLORS = ['#D4622A', '#5B7FA6', '#4A9B6F', '#9B6B4A', '#7A5BA6', '#A65B7A', '#5B9B8A'];
function avatarColor(name) { let h = 0; for (let c of name) h = (h + c.charCodeAt(0)) % AVATAR_COLORS.length; return AVATAR_COLORS[h]; }
function initials(name) { return name.split(/[\s_]/).map(w => w[0]).join('').toUpperCase().slice(0, 2); }

const DATA = {
    topics: [
        { id: 1, title: "yazılım", count: 247 },
        { id: 2, title: "asp.net core", count: 83 },
        { id: 3, title: "yapay zeka", count: 512 },
        { id: 4, title: "girişimcilik", count: 194 },
        { id: 5, title: "typescript", count: 136 },
        { id: 6, title: "uzaktan çalışma", count: 321 },
        { id: 7, title: "react", count: 208 },
        { id: 8, title: "linux", count: 175 },
        { id: 9, title: "blockchain", count: 99 },
        { id: 10, title: "siber güvenlik", count: 143 },
        { id: 11, title: "açık kaynak", count: 267 },
        { id: 12, title: "makine öğrenmesi", count: 389 },
        { id: 13, title: "ux tasarım", count: 118 },
        { id: 14, title: "postgresql", count: 74 },
        { id: 15, title: "docker", count: 162 },
    ],
    entries: {
        1: [
            { id: 101, text: "Yazılım geliştirme, aslında sürekli bir problem çözme serüvenidir. Her bug, aslında sizi daha iyi bir düşünür yapan bir bulmacadır. Sabah kalktığınızda 'bugün hangi sorunu çözeceğim?' diye düşünüyorsanız, doğru iştesiniz demektir.", author: "ayse_kaya", date: "04.05.2026 09:14", likes: 42, faved: false, liked: false },
            { id: 102, text: "Clean code yazmak sadece bir teknik beceri değil; empati gerektiren bir sanattır. Yazdığınız kodu 6 ay sonra okuyacak olan kişi (büyük ihtimalle siz olacaksınız), o an için ne kadar minnettar olacağını düşünün.", author: "mehmet_dev", date: "04.05.2026 11:32", likes: 89, faved: false, liked: false },
            { id: 103, text: "'Bende çalışıyor' cümlesi bir programcının en tehlikeli cümlesidir. Production ortamı her zaman sizin local'inizden farklı davranır; bunu asla unutmayın. Docker bu sorunu büyük ölçüde çözdü ama sorun tamamen bitmedi.", author: "zeynep_tech", date: "03.05.2026 18:45", likes: 156, faved: false, liked: false },
            { id: 104, text: "Yazılımda en zor kısım teknik değil, iletişimdir. Müşterinin ne istediğini anlamak, o isteği teknik gereksinime çevirmek ve sonucu yine müşteriye anlaşılır biçimde sunmak — bu zincirdeki her halka kritiktir.", author: "ali_backend", date: "02.05.2026 14:20", likes: 234, faved: false, liked: false },
        ],
        2: [
            { id: 201, text: "ASP.NET Core'un Minimal API özelliği sayesinde artık çok daha az kod ile güçlü REST API'lar yazabiliyoruz. Eski Web API'ye kıyasla öğrenme eğrisi de epey düzeldi. Microsoft bu seferlik gerçekten doğru yapmış.", author: "ozan_net", date: "05.05.2026 08:10", likes: 31, faved: false, liked: false },
            { id: 202, text: "Entity Framework Core 8 ile gelen raw SQL desteği ve JSON kolon özelliği gerçekten oyun değiştirici. Artık complex query'ler için Dapper'a geçmek zorunda kalmıyorsunuz. ORM ve raw SQL arasındaki denge mükemmelleşti.", author: "selin_aspnet", date: "04.05.2026 16:55", likes: 77, faved: false, liked: false },
            { id: 203, text: "Dependency Injection .NET Core'un ruhundadır. Bunu kavramadan framework'ü gerçek anlamda kullanmak mümkün değil. IServiceCollection'ı iyi anladıktan sonra her şey yerli yerine oturuyor.", author: "berk_developer", date: "03.05.2026 10:00", likes: 115, faved: false, liked: false },
        ],
        3: [
            { id: 301, text: "ChatGPT'nin çıkışından bu yana geçen 2 yıl içinde yapay zekanın gelişimi insanlığın 20 yılını sıkıştırdı. Anthropic, OpenAI, Google DeepMind... Bu yarışın kazananını tahmin etmek neredeyse imkânsız ama kaybeden kesinlikle olmayacak gibi görünüyor.", author: "nilay_ai", date: "05.05.2026 10:30", likes: 321, faved: false, liked: false },
            { id: 302, text: "LLM'lerin halüsinasyon problemi hâlâ tam anlamıyla çözülmüş değil. RAG (Retrieval Augmented Generation) bu soruna iyi bir bant-aid ama kalıcı çözüm değil. Model mimarisi seviyesinde bir çözüm beklemek mantıklı.", author: "emre_ml", date: "05.05.2026 07:45", likes: 198, faved: false, liked: false },
            { id: 303, text: "'Yapay zeka işlerimizi elinden alacak' retoriği artık eskidi. Daha doğru soru şu: Yapay zekayı kullananlar, kullanmayanların işlerini alacak mı? Ve cevabı muhtemelen evet.", author: "canan_future", date: "04.05.2026 22:10", likes: 445, faved: false, liked: false },
            { id: 304, text: "Multimodal modeller düşündüğümüzden çok daha hızlı gelişti. Görüntü, ses, video ve metin aynı anda işlenebiliyor artık. Bu, robotik ve otomasyon alanlarında gerçek devrime kapı açıyor.", author: "kerem_robotics", date: "04.05.2026 14:00", likes: 267, faved: false, liked: false },
            { id: 305, text: "Prompt mühendisliği denen şey kısa süre içinde ortadan kalkacak. Modeller zaten niyeti anlıyor; ileride nasıl sorduğumuz değil ne istediğimiz önemli olacak. Bu da bir mesleğin doğup ölmesini izlediğimiz anlamına geliyor.", author: "dogan_nlp", date: "03.05.2026 19:22", likes: 189, faved: false, liked: false },
        ],
        4: [
            { id: 401, text: "Girişimcilik, belirsizliğe tolerans gösterebilme sanatıdır. Çoğu insan 'iyi fikrim var ama' der ve durur. Gerçek girişimci 'fikrim mükemmel değil ama' der ve başlar. Mükemmeliyetçilik en tehlikeli düşmandır.", author: "tarık_startup", date: "05.05.2026 09:00", likes: 178, faved: false, liked: false },
            { id: 402, text: "Türkiye'de girişimcilik ekosistemi son 5 yılda inanılmaz gelişti. Teknoloji yatırımları, kuluçka merkezleri, devlet destekleri... Ama hâlâ eksik olan şey: başarısızlığa tolerans kültürü. Silicon Valley'de başarısızlık rozet gibi taşınır, bizde hâlâ ayıp.", author: "pınar_vc", date: "04.05.2026 13:40", likes: 302, faved: false, liked: false },
            { id: 403, text: "Product-market fit denen şeyi anlamak için yüzlerce müşteri görüşmesi yapmanız gerekiyor. Hiç kimse size 'evet bu ürüne para veririm' demiyorsa, ne kadar iyi geliştirirseniz geliştirin, boşuna harcanan enerji.", author: "volkan_product", date: "03.05.2026 11:15", likes: 234, faved: false, liked: false },
        ],
        5: [
            { id: 501, text: "TypeScript başlangıçta boilerplate gibi hissettiriyor, ama 3 ay sonra type sisteminin kurtardığı her bug için teşekkür ediyorsunuz. Özellikle büyük takımlarda TypeScript olmadan çalışmayı artık hayal bile edemiyorum.", author: "elif_ts", date: "05.05.2026 11:20", likes: 93, faved: false, liked: false },
            { id: 502, text: "'any' tipi TypeScript'in en büyük günahıdır. Bunu kullanan kişi aslında 'bu kısmı düşünmek istemiyorum' diyor. Teknik borç birikiyor ve zamanla tüm tip sisteminin değerini sıfıra indiriyor.", author: "furkan_types", date: "04.05.2026 17:30", likes: 147, faved: false, liked: false },
        ],
        6: [
            { id: 601, text: "Uzaktan çalışma en büyük iş devrimi oldu. Ofis kirasını, servis masrafını, yemek masrafını düşündüğünüzde şirketler de ciddi tasarruf etti. Verimlilik artışının üzerine bir de kira geliyor; işverenlerin geri dönmekte ısrar etmesinin sebebi başka.", author: "hande_remote", date: "05.05.2026 08:55", likes: 412, faved: false, liked: false },
            { id: 602, text: "'Evden çalışırken nasıl odaklanıyorsunuz?' sorusu hâlâ soruluyorsa, o kişi asla ofiste de tam anlamıyla odaklanamamıştır. Odaklanma bir ortam değil, bir beceri meselesidir.", author: "serhat_wfh", date: "04.05.2026 20:10", likes: 267, faved: false, liked: false },
        ],
        7: [{ id: 701, text: "React Hooks çıktığında 'bu ne gereksizlik' diye düşünmüştüm. Şimdi class component yazan birini görünce içim cızıldıyor. useState ve useEffect ikisini gerçekten kavrayınca bütün dünya değişiyor.", author: "güneş_react", date: "05.05.2026 10:05", likes: 88, faved: false, liked: false }],
        8: [{ id: 801, text: "Linux'a geçiş yaşam kalitenizi artırır mı? Evet, ama önce 3 ay çekeceksiniz. Printer driver kurma macerasını atlattıktan sonra artık o sisteme geri dönmek istemiyorsunuz.", author: "tuna_linux", date: "04.05.2026 15:30", likes: 203, faved: false, liked: false }],
        9: [{ id: 901, text: "Blockchain teknolojisi gerçekten devrimci ama %90 kullanım vakası aslında daha basit çözümlerle daha verimli yapılabilir. 'Blockchain lazım mı?' sorusunu sormak yerine 'neden blockchain?' sorusunu sormak gerekiyor.", author: "arda_crypto", date: "03.05.2026 09:40", likes: 175, faved: false, liked: false }],
        10: [{ id: 1001, text: "Zero-trust mimarisi artık lüks değil zorunluluk. 'Ağın içindeyse güvenlidir' anlayışı tamamen bitti. Her istek, her kullanıcı, her cihaz ayrı ayrı doğrulanmalı. Bunu küçük şirketlere anlatmak hâlâ zor.", author: "seda_security", date: "05.05.2026 07:00", likes: 134, faved: false, liked: false }],
        11: [{ id: 1101, text: "Açık kaynak, yazılım dünyasının en büyük hediyesidir. Linux, React, PostgreSQL, VS Code... Bunların hiçbiri olmasaydı modern yazılım endüstrisi bu kadar hızlı gelişemezdi. Kullandığınız açık kaynak projeye katkı yapın — kod değil, dokümantasyon bile yeterli.", author: "ilkay_oss", date: "04.05.2026 12:00", likes: 289, faved: false, liked: false }],
        12: [{ id: 1201, text: "PyTorch mu TensorFlow mu tartışması artık çoktan kapandı. Akademi PyTorch'a geçti; endüstri de yavaş yavaş geliyor. Google kendi framework'ünü korumak için çabalıyor ama ecosystem zaten konuştu.", author: "burak_ml", date: "05.05.2026 09:30", likes: 167, faved: false, liked: false }],
        13: [{ id: 1301, text: "UX tasarım, kullanıcının ne istediğini değil ne ihtiyaç duyduğunu bulmaktır. Çoğu zaman kullanıcı 'daha hızlı at' ister, oysa aslında ihtiyacı 'araba'dır. Bu farkı görebilmek tasarımcının en önemli becerisidir.", author: "merve_ux", date: "04.05.2026 16:00", likes: 221, faved: false, liked: false }],
        14: [{ id: 1401, text: "PostgreSQL 16 ile gelen paralel query execution ve logical replication iyileştirmeleri production'da ciddi performans kazanımları sağlıyor. MySQL'den geçenler genelde bir daha geri dönmüyor.", author: "onur_postgres", date: "03.05.2026 14:45", likes: 98, faved: false, liked: false }],
        15: [{ id: 1501, text: "Docker olmadan önceki hayatı artık hatırlamak istemiyorum. 'Bende çalışıyor' probleminin %80'ini çözdü. Geri kalan %20'si için Kubernetes var ama onu da ayrı bir dert olarak not edelim.", author: "adem_devops", date: "05.05.2026 08:00", likes: 143, faved: false, liked: false }],
    }
};

/* ══════════════ STATE ══════════════ */
let state = {
    activeTopicId: null,
    sort: 'newest',
    entries: JSON.parse(JSON.stringify(DATA.entries)), // deep clone
};

/* ══════════════ HELPERS ══════════════ */
function showToast(msg) {
    const t = document.getElementById('toast');
    t.textContent = msg; t.classList.add('show');
    setTimeout(() => t.classList.remove('show'), 2200);
}

function sortedEntries(entries) {
    const list = [...entries];
    if (state.sort === 'newest') return list.sort((a, b) => b.id - a.id);
    if (state.sort === 'oldest') return list.sort((a, b) => a.id - b.id);
    if (state.sort === 'popular') return list.sort((a, b) => b.likes - a.likes);
    return list;
}

/* ══════════════ RENDER TOPIC LIST ══════════════ */
function renderTopics(filter = '') {
    const list = document.getElementById('topic-list');
    const filtered = DATA.topics.filter(t => t.title.toLowerCase().includes(filter.toLowerCase()));
    list.innerHTML = filtered.map(t => `
    <div class="topic-item ${state.activeTopicId === t.id ? 'active' : ''}"
         data-id="${t.id}" role="button" tabindex="0">
      <span class="topic-title">${highlight(t.title, filter)}</span>
      <span class="topic-count">${t.count}</span>
    </div>`).join('') || `<div style="padding:1.5rem 1rem;font-size:.82rem;color:var(--text-muted)">Sonuç bulunamadı.</div>`;

    list.querySelectorAll('.topic-item').forEach(el => {
        el.addEventListener('click', () => selectTopic(+el.dataset.id));
        el.addEventListener('keydown', e => { if (e.key === 'Enter') selectTopic(+el.dataset.id); });
    });
}

function highlight(text, q) {
    if (!q) return text;
    return text.replace(new RegExp(`(${q})`, 'gi'), '<mark style="background:var(--accent-soft);color:var(--accent);border-radius:3px;padding:0 2px">$1</mark>');
}

/* ══════════════ RENDER TRENDING CHIPS ══════════════ */
function renderChips() {
    const strip = document.getElementById('trendingStrip');
    const trending = DATA.topics.slice(0, 8);
    strip.innerHTML = `<span class="chip" style="opacity:.6;cursor:default;font-weight:600">🔥 Trend:</span>` +
        trending.map(t => `<span class="chip ${state.activeTopicId === t.id ? 'active' : ''}" data-id="${t.id}">${t.title}</span>`).join('');
    strip.querySelectorAll('.chip[data-id]').forEach(el =>
        el.addEventListener('click', () => selectTopic(+el.dataset.id)));
}

/* ══════════════ SELECT TOPIC ══════════════ */
function selectTopic(id) {
    state.activeTopicId = id;
    closeSidebar();
    renderTopics(document.getElementById('sidebarSearch').value);
    renderChips();
    renderContent();
}

/* ══════════════ RENDER CONTENT ══════════════ */
function renderContent() {
    const id = state.activeTopicId;
    const topic = DATA.topics.find(t => t.id === id);
    const container = document.getElementById('entries-container');

    document.getElementById('contentTitle').innerHTML = topic
        ? `<em>${topic.title}</em>`
        : 'Bir başlık seçin';

    const entries = state.entries[id] || [];
    document.getElementById('contentCount').textContent =
        topic ? `${entries.length} entry` : '— entry';
    document.getElementById('modalTopicName').textContent = topic ? topic.title : '';

    if (!topic || !entries.length) {
        container.innerHTML = `<div class="empty-state">
      <i class="bi bi-journal-x"></i>
      <h4>${topic ? 'Henüz entry yok' : 'Bir başlık seçin'}</h4>
      <p>${topic ? 'İlk entry\'i sen yaz!' : 'Sol panelden bir başlık seçerek başla.'}</p>
    </div>`;
        return;
    }

    const sorted = sortedEntries(entries);
    container.innerHTML = sorted.map((e, idx) => `
    <div class="entry-card" style="animation-delay:${idx * 0.04}s" data-eid="${e.id}">
      <div class="entry-text">${e.text}</div>
      <div class="entry-footer">
        <div class="entry-meta">
          <div class="entry-avatar" style="background:${avatarColor(e.author)}">${initials(e.author)}</div>
          <div>
            <div class="entry-author">@${e.author}</div>
            <div class="entry-date"><i class="bi bi-clock" style="font-size:.7rem"></i> ${e.date}</div>
          </div>
        </div>
        <div class="entry-actions">
          <button class="action-btn ${e.liked ? 'liked' : ''}" data-action="like" data-eid="${e.id}" title="Beğen">
            <i class="bi bi-hand-thumbs-up${e.liked ? '-fill' : ''}"></i> ${e.likes}
          </button>
          <button class="action-btn ${e.faved ? 'faved' : ''}" data-action="fav" data-eid="${e.id}" title="Favorile">
            <i class="bi bi-bookmark${e.faved ? '-fill' : ''}"></i>
          </button>
          <button class="action-btn" data-action="share" title="Paylaş">
            <i class="bi bi-share"></i>
          </button>
        </div>
      </div>
    </div>`).join('');

    container.querySelectorAll('[data-action]').forEach(btn => {
        btn.addEventListener('click', () => handleAction(btn.dataset.action, +btn.dataset.eid));
    });
}

/* ══════════════ ACTIONS ══════════════ */
function handleAction(action, eid) {
    const id = state.activeTopicId;
    const entries = state.entries[id];
    if (!entries) return;
    const e = entries.find(x => x.id === eid);
    if (!e) return;
    if (action === 'like') {
        e.liked = !e.liked;
        e.likes += e.liked ? 1 : -1;
        showToast(e.liked ? '👍 Beğenildi!' : 'Beğeni geri alındı.');
    } else if (action === 'fav') {
        e.faved = !e.faved;
        showToast(e.faved ? '🔖 Favorilere eklendi!' : 'Favorilerden çıkarıldı.');
    } else if (action === 'share') {
        showToast('Paylaşım bağlantısı sonraki aşamada eklenecek.');
    }
    renderContent();
}

/* ══════════════ NEW ENTRY MODAL ══════════════ */
const modal = document.getElementById('entryModal');
document.getElementById('newEntryBtn').addEventListener('click', () => {
    if (!state.activeTopicId) { showToast('Önce bir başlık seç!'); return; }
    document.getElementById('entryTextarea').value = '';
    document.getElementById('charCount').textContent = '0 karakter';
    modal.classList.add('open');
    document.getElementById('entryTextarea').focus();
});
document.getElementById('cancelModal').addEventListener('click', () => modal.classList.remove('open'));
modal.addEventListener('click', e => { if (e.target === modal) modal.classList.remove('open'); });

document.getElementById('entryTextarea').addEventListener('input', function () {
    document.getElementById('charCount').textContent = `${this.value.length} karakter`;
});

document.getElementById('submitEntry').addEventListener('click', () => {
    const text = document.getElementById('entryTextarea').value.trim();
    if (text.length < 5) { showToast('Entry çok kısa!'); return; }
    const id = state.activeTopicId;
    const newEntry = {
        id: Date.now(), text,
        author: 'sen_missin', date: new Date().toLocaleString('tr-TR'),
        likes: 0, liked: false, faved: false
    };
    if (!state.entries[id]) state.entries[id] = [];
    state.entries[id].unshift(newEntry);
    const topic = DATA.topics.find(t => t.id === id);
    if (topic) topic.count++;
    modal.classList.remove('open');
    renderTopics(document.getElementById('sidebarSearch').value);
    renderContent();
    showToast('Demo entry eklendi; henüz veritabanına kaydedilmiyor.');
});

/* ══════════════ SORT ══════════════ */
document.getElementById('sortBar').querySelectorAll('.sort-btn').forEach(btn => {
    btn.addEventListener('click', () => {
        document.querySelectorAll('.sort-btn').forEach(b => b.classList.remove('active'));
        btn.classList.add('active');
        state.sort = btn.dataset.sort;
        renderContent();
    });
});

/* ══════════════ SEARCH (GLOBAL) ══════════════ */
document.getElementById('globalSearch').addEventListener('input', function () {
    document.getElementById('sidebarSearch').value = this.value;
    renderTopics(this.value);
    // auto-select first match
    const match = DATA.topics.find(t => t.title.toLowerCase().includes(this.value.toLowerCase()));
    if (match && this.value) selectTopic(match.id);
});
document.getElementById('sidebarSearch').addEventListener('input', function () {
    renderTopics(this.value);
});

/* ══════════════ THEME ══════════════ */
const themeBtn = document.getElementById('themeToggle');
const themeIcon = document.getElementById('themeIcon');
function applyTheme(dark) {
    document.documentElement.setAttribute('data-theme', dark ? 'dark' : 'light');
    themeIcon.className = dark ? 'bi bi-sun-fill' : 'bi bi-moon-stars-fill';
    localStorage.setItem('szx-theme', dark ? 'dark' : 'light');
}
const savedTheme = localStorage.getItem('szx-theme');
if (savedTheme) applyTheme(savedTheme === 'dark');
themeBtn.addEventListener('click', () => {
    applyTheme(document.documentElement.getAttribute('data-theme') !== 'dark');
});

/* ══════════════ SIDEBAR MOBILE ══════════════ */
const sidebar = document.getElementById('sidebar');
const overlay = document.getElementById('sidebarOverlay');
function openSidebar() { sidebar.classList.add('open'); overlay.classList.add('open'); }
function closeSidebar() { sidebar.classList.remove('open'); overlay.classList.remove('open'); }
document.getElementById('hamburgerBtn').addEventListener('click', openSidebar);
overlay.addEventListener('click', closeSidebar);

/* ══════════════ INIT ══════════════ */
renderTopics();
renderChips();
