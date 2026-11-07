(function () {
    var toggle = document.getElementById('szMenuOpen');
    var backdrop = document.getElementById('szBackdrop');
    var sidebar = document.getElementById('szSidebar');
    if (!toggle || !backdrop || !sidebar) return;
    function openMenu(on) { sidebar.classList.toggle('open', on); backdrop.classList.toggle('open', on); toggle.setAttribute('aria-expanded', String(on)); }
    toggle.addEventListener('click', function () { openMenu(!sidebar.classList.contains('open')); });
    backdrop.addEventListener('click', function () { openMenu(false); });
    document.addEventListener('keydown', function (e) { if (e.key === 'Escape') openMenu(false); });
})();
