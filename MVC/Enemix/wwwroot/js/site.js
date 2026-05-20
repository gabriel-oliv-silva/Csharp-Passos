// Lógica do Dark Mode
// Lógica do Dark Mode com View Transition
document.addEventListener('DOMContentLoaded', () => {
    const html = document.documentElement;
    const btn = document.getElementById('themeToggle');
    if (!btn) return;

    const icon = btn.querySelector('i');

    btn.addEventListener('click', (e) => { // <--- Adicione o 'e' aqui
        const aplicarAlteracoesDOM = () => {
            const current = html.getAttribute('data-bs-theme');
            const newTheme = current === 'light' ? 'dark' : 'light';
            html.setAttribute('data-bs-theme', newTheme);
            localStorage.setItem('enemix-theme', newTheme);
            updateIcon(newTheme);
        };

        // Fallback para navegadores que não suportam View Transition API
        if (!document.startViewTransition) {
            aplicarAlteracoesDOM();
            return;
        }

        const transition = document.startViewTransition(aplicarAlteracoesDOM);

        transition.ready.then(() => {
            // Pega a posição do clique ou o centro da tela
            const x = e.clientX ?? window.innerWidth / 2;
            const y = e.clientY ?? window.innerHeight / 2;

            const endRadius = Math.hypot(
                Math.max(x, window.innerWidth - x),
                Math.max(y, window.innerHeight - y)
            );

            document.documentElement.animate(
                {
                    clipPath: [
                        `circle(0px at ${x}px ${y}px)`,
                        `circle(${endRadius}px at ${x}px ${y}px)`,
                    ],
                },
                {
                    duration: 500,
                    easing: "ease-in-out",
                    pseudoElement: "::view-transition-new(root)",
                }
            );
        });
    });
    function updateIcon(theme) {
        icon.className = theme === 'light' ? 'bi bi-moon-stars-fill' : 'bi bi-sun-fill';
    }
    const cards = document.querySelectorAll('.btn-abrir-modal');

    cards.forEach(card => {
        card.addEventListener('click', function() {
            // Pegamos os dados usando o objeto dataset (muito mais limpo)
            const id = this.dataset.id;
            const titulo = this.dataset.titulo;
            const imagem = this.dataset.imagem;
            const descricao = this.dataset.descricao;
            const areaId = this.dataset.area;

            abrirModalEstudo(id, titulo, imagem, descricao, areaId);
        });
    });
});

// Lógica para abrir o Modal de Pílula de Estudo injetando a cor correta
function abrirModalEstudo(id, titulo, imagem, descricao, areaId) {
    const modalElement = document.getElementById('modalEstudo');
    if (!modalElement) return;

    // Mapeamento de áreas para classes CSS
    const classes = { 1: 'linguagens', 2: 'humanas', 3: 'natureza', 4: 'matematica' };
    const areaClass = classes[areaId] || 'linguagens';

    // 1. Estilização Dinâmica
    const header = modalElement.querySelector('.modal-header');
    if(header) header.className = `modal-header modal-header-area bg-${areaClass}`;

    // 2. Preenchimento de Conteúdo
    document.getElementById('modalTitulo').innerText = titulo;

    // O .innerHTML aqui funciona perfeitamente porque o navegador 
    // já tratou o dado vindo do data-attribute
    document.getElementById('modalConteudo').innerHTML = descricao;

    // 3. Tratamento da Imagem
    const imgElement = document.getElementById('modalImagem');
    if(imgElement) {
        imgElement.src = imagem || '';
        imgElement.style.display = (imagem && imagem !== 'null') ? 'block' : 'none';
    }

    // 4. Exibição do Modal
    const modalInstance = bootstrap.Modal.getOrCreateInstance(modalElement);
    modalInstance.show();
}