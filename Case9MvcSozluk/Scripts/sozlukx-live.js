(function () {
    'use strict';
    var topics = Array.prototype.slice.call(document.querySelectorAll('#topic-list .topic-item'));
    var chips = Array.prototype.slice.call(document.querySelectorAll('#trendingStrip [data-heading-id]'));
    var sections = Array.prototype.slice.call(document.querySelectorAll('.sx-heading-entries'));
    var headingTitle = document.getElementById('contentTitle');
    var contentCount = document.getElementById('contentCount');
    var count = function (id) { var s = document.querySelector('[data-heading-section="' + id + '"]'); return s ? s.querySelectorAll('.entry-card').length : 0; };
    var active = null;
    function select(id) {
        var t = topics.find(function (x) { return x.dataset.headingId === String(id); }); if (!t) return;
        active = String(id);
        topics.forEach(function (x) { x.classList.toggle('active', x === t); });
        chips.forEach(function (x) { x.classList.toggle('active', x.dataset.headingId === active); });
        sections.forEach(function (x) { x.style.display = (x.dataset.headingSection === active ? '' : 'none'); });
        headingTitle.textContent = t.dataset.title;
        contentCount.textContent = count(active) + ' entry';
        var hidden = document.getElementById('entryHeadingID'); if (hidden) hidden.value = active;
        var n = document.getElementById('modalTopicName'); if (n) n.textContent = t.dataset.title;
        closeSidebar();
        if (window.history && window.history.replaceState) history.replaceState(null, '', window.location.pathname + '?id=' + encodeURIComponent(id));
    }
    topics.forEach(function (x) { x.addEventListener('click', function () { select(x.dataset.headingId); }); });
    chips.forEach(function (x) { x.addEventListener('click', function () { select(x.dataset.headingId); }); });
    var g = document.getElementById('globalSearch'), s = document.getElementById('sidebarSearch');
    function search(q) { q = (q || '').toLocaleLowerCase('tr-TR').trim(); topics.forEach(function (t) { t.style.display = t.dataset.title.toLocaleLowerCase('tr-TR').indexOf(q) >= 0 ? '' : 'none'; }); }
    [g, s].forEach(function (field) { if (field) field.addEventListener('input', function () { search(field.value); if (field === g && s) s.value = field.value; }); });
    var sorts = Array.prototype.slice.call(document.querySelectorAll('[data-sort]'));
    sorts.forEach(function (b) {
        b.addEventListener('click', function () {
            sorts.forEach(function (x) { x.classList.toggle('active', x === b); }); sections.forEach(function (sec) {
                var cards = Array.prototype.slice.call(sec.querySelectorAll('.entry-card'));
                cards.sort(function (a, c) { return (b.dataset.sort === 'oldest' ? 1 : -1) * (Number(a.dataset.entryDate) - Number(c.dataset.entryDate)); });
                cards.forEach(function (card) { sec.insertBefore(card, sec.querySelector('.empty-state')); });
            });
        });
    });
    var modal = document.getElementById('entryModal'), open = document.getElementById('newEntryBtn'), cancel = document.getElementById('cancelModal');
    if (open) open.addEventListener('click', function () { if (!active) return; modal.classList.add('open'); });
    if (cancel) cancel.addEventListener('click', function () { modal.classList.remove('open'); });
    if (modal) modal.addEventListener('click', function (e) { if (e.target === modal) modal.classList.remove('open'); });
    var area = document.getElementById('entryTextarea'), c = document.getElementById('charCount'); if (area && c) area.addEventListener('input', function () { c.textContent = area.value.length + ' / 5000 karakter'; });
    var theme = document.getElementById('themeToggle'), icon = document.getElementById('themeIcon');
    function setTheme(d) { document.documentElement.dataset.theme = d ? 'dark' : 'light'; if (icon) icon.className = d ? 'bi bi-sun-fill' : 'bi bi-moon-stars-fill'; try { localStorage.setItem('szx-theme', d ? 'dark' : 'light'); } catch (e) { } }
    try { setTheme(localStorage.getItem('szx-theme') === 'dark'); } catch (e) { }
    if (theme) theme.addEventListener('click', function () { setTheme(document.documentElement.dataset.theme !== 'dark'); });
    var side = document.getElementById('sidebar'), overlay = document.getElementById('sidebarOverlay');
    function closeSidebar() { if (side) side.classList.remove('open'); if (overlay) overlay.classList.remove('open'); }
    var burger = document.getElementById('hamburgerBtn'); if (burger) burger.addEventListener('click', function () { side.classList.add('open'); overlay.classList.add('open'); });
    if (overlay) overlay.addEventListener('click', closeSidebar);
    document.querySelectorAll('.sx-entry-delete').forEach(function (b) { b.addEventListener('click', function (e) { if (!confirm('Bu entry silinsin mi?')) e.preventDefault(); }); });
    var initial = document.querySelector('#topic-list .topic-item.active') || topics[0]; if (initial) select(initial.dataset.headingId);
})();