function adcAluno() {
    const campos = {
        nome: document.getElementById('nome').value.trim(),
        idade: document.getElementById('idade').value.trim(),
        nota: document.getElementById('nota').value.trim(),
        matricula: document.getElementById('matricula').value.trim()
    };

    const algumVazio = Object.values(campos).some(v => v === "");
    if (algumVazio) {
        alert("Preencha todos os campos!");
        return;
    }
    if (campos.nota > 10){
        alert("A nota não pode ser maior que 10;")
        return campos.nota.focus();
    }
    if (campos.nota < 0){
        alert("A nota não pode ser negativa.")
        return campos.nota.focus();
    }
    if (campos.matricula < 1){
        alert("A matrícula não pode ser negativa ou 0.")
        return campos.matricula.focus();
    }
    

    const dados = JSON.parse(localStorage.getItem("tabelaAluno")) || [];

    if (dados.some(dado => dado.matricula === campos.matricula)) {
        alert("O aluno já existe!");
        return;
    }

    dados.push(campos);
    localStorage.setItem("tabelaAluno", JSON.stringify(dados));
    renderTabela();
}
function EditarAluno() {
    const matricula = document.getElementById('matricula').value;
    let dados = JSON.parse(localStorage.getItem("tabelaAluno")) || [];
    const dadosAntigos = dados.find(dado => dado.matricula === matricula);
    if (dadosAntigos != null) {

        document.getElementsByTagName('table')[0].innerHTML = `
        
        <tr>
            <td>
                <label for="nome" class="form-label input-group-text">Nome:</label>
            </td>
        </tr>
        <tr>
            <td>
                <input type="text" value="${dadosAntigos.nome}" id="nome" class="input-group" placeholder="Insira o nome do aluno" required/>
            </td>
        </tr>
        <tr>
            <td>
                <label for="idade" class="form-label input-group-text">Idade:</label>
            </td>
        </tr>
        <tr>

            <td>
                <input type="number" value="${dadosAntigos.idade}" id="idade" max="25" class="input-group" placeholder="Insira a idade do aluno" required/>
            </td>
        </tr>
        <tr>

            <td>
                <label for="nota" class="form-label input-group-text">Nota geral:</label>
            </td>
        </tr>
        <tr>
            <td>
                <input type="number" value="${dadosAntigos.nota}" id="nota" class="input-group" max="10" min="0" placeholder="Insira a nota geral do aluno" required/>
            </td>
        </tr>
        <tr>
            <td>
                <input type="submit" class="btn btn-success" id="submit" value="Atualizar"/>
            </td>
        </tr>

        
        `;
        document.getElementById('submit').addEventListener("click", function () {

            const campos = {
                nome: document.getElementById('nome').value.trim(),
                idade: document.getElementById('idade').value.trim(),
                nota: document.getElementById('nota').value.trim(),
                matricula: document.getElementById('matricula').value.trim()
            };

            const algumVazio = Object.values(campos).some(v => v === "");
            if (algumVazio) {
                alert("Preencha todos os campos!");
                return;
            }
            if (campos.nota > 10){
                alert("A nota não pode ser maior que 10;")
                return campos.nota.focus();
            }
            if (campos.nota < 0){
                alert("A nota não pode ser negativa.")
                return campos.nota.focus();
            }
            if (campos.idade > 25)
               alert("Aluno velho demais!");
            
            if (campos.matricula < 1){
                alert("A matrícula não pode ser negativa ou 0.")
                return campos.matricula.focus();
            }

            
                dados = dados.filter(dado => dado.matricula !== campos.matricula);
                dados.push({campos});
                localStorage.setItem("tabelaAluno", JSON.stringify(dados));
                alert(`${nome} atualizado com sucesso!`);
            

        });

    } else {
        alert("Aluno não encontrado!")
    }

}

function trocarnav(i) {
    const opcoes = document.querySelectorAll(".nav-link");

    opcoes.forEach((el, index) => {
        el.classList.toggle("ativo", index === i);
    });
}


function DeletarAluno() {
    const matricula = document.getElementById('matricula').value;
    let dados = JSON.parse(localStorage.getItem("tabelaAluno")) || [];
    const tamanhoAntes = dados.length;
    dados = dados.filter(dado => dado.matricula !== matricula);
    const tamanhoDepois = dados.length;
    if (tamanhoAntes !== tamanhoDepois) {
        alert("Aluno deletado com sucesso!")
        localStorage.setItem("tabelaAluno", JSON.stringify(dados));

        setTimeout(function () {
            window.location.reload();
        }, 2000)
    } else {
        alert("Aluno não encontrado!");
    }


}

function DeletarTodosAluno() {
    localStorage.clear();
    alert("Lista limpa com sucesso!");
}

function renderTabela() {
    const dados = JSON.parse(localStorage.getItem("tabelaAluno")) || [];
    const tbody = document.getElementById("table");
    tbody.innerHTML = "";

    dados.forEach(item => {
        const tr = document.createElement("div");
        if (item.nota >= 7) {
            tr.innerHTML = `

      <div class="card flex-column">
        <h5 class="card-header border-bottom">${item.nome}</h5>
        <div class="card-body">
        <p class="card-subtitle" >Nº: ${item.matricula}</p>
        <p class="card-title">${item.idade} anos</p>
        <p class="card-text">${item.nota} pontos</p>
        </div>
        <div class="card-footer alert-success">Aprovado</div>  
      </div>

      `;
        } else {
            tr.innerHTML = `
      <div class="card flex-column h-100">
        <h5 class="card-header border-bottom">${item.nome}</h5>
        <div class="card-body">
        <p class="card-subtitle" >Nº: ${item.matricula}</p>
        <p class="card-title">${item.idade} anos</p>
        <p class="card-text">${item.nota} pontos</p>
        </div>
        <div class="card-footer alert-danger">Reprovado</div>  
      </div>
    `;

        }
        tbody.appendChild(tr);
    });
}

window.onload = renderTabela;