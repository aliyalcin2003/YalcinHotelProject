(() => {
    const toggle = document.querySelector('[data-admin-menu-toggle]');
    if (!toggle) return;

    toggle.addEventListener('click', () => {
        document.body.classList.toggle('sidebar-open');
    });

    document.addEventListener('click', (event) => {
        if (window.innerWidth > 700 || !document.body.classList.contains('sidebar-open')) return;
        const sidebar = document.querySelector('[data-admin-sidebar]');
        if (!sidebar?.contains(event.target) && !toggle.contains(event.target)) {
            document.body.classList.remove('sidebar-open');
        }
    });

    window.addEventListener('resize', () => {
        if (window.innerWidth > 700) document.body.classList.remove('sidebar-open');
    });
})();
