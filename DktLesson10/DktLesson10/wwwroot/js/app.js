document.documentElement.classList.add('js');
const toggle = document.querySelector('.menu-toggle');
const nav = document.querySelector('#site-nav');
function closeMenu() { nav?.classList.remove('open'); toggle?.setAttribute('aria-expanded', 'false'); }
toggle?.addEventListener('click', () => { const open = nav.classList.toggle('open'); toggle.setAttribute('aria-expanded', String(open)); });
nav?.addEventListener('click', event => { if (event.target.closest('a')) closeMenu(); });
document.addEventListener('keydown', event => { if (event.key === 'Escape' && nav?.classList.contains('open')) { closeMenu(); toggle.focus(); } });
const filters = document.querySelector('.filters');
if (filters) {
  filters.hidden = false;
  filters.addEventListener('click', event => {
    const button = event.target.closest('[data-filter]');
    if (!button) return;
    for (const item of filters.querySelectorAll('button')) item.setAttribute('aria-pressed', String(item === button));
    let visible = 0;
    for (const card of document.querySelectorAll('[data-project]')) { card.hidden = button.dataset.filter !== 'all' && button.dataset.filter !== card.dataset.project; if (!card.hidden) visible++; }
    document.querySelector('#project-status').textContent = `${visible} ${visible === 1 ? 'project' : 'projects'} shown`;
  });
}
const printButton = document.querySelector('[data-print]');
if (printButton) { printButton.hidden = false; printButton.addEventListener('click', () => window.print()); }
