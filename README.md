```text
  _______ _    _ ______   _   _ _____ _   _ _______ _    _   
 |__   __| |  | |  ____| | \ | |_   _| \ | |__   __| |  | |
    | |  | |__| | |__    |  \| | | | |  \| |  | |  | |__| |
    | |  |  __  |  __|   | . ` | | | | . ` |  | |  |  __  |
    | |  | |  | | |____  | |\  |_| |_| |\  |  | |  | |  | |
    |_|  |_|  |_|______| |_| \_|_____|_| \_|  |_|  |_|  |_|
                                                           
  __          __  _      _  __  ______ _____               
  \ \        / / / \    | |/ / |  ____|  __ \              
   \ \  /\  / / / _ \   | ' /  | |__  | |__) |             
    \ \/  \/ / / ___ \  |  <   |  __| |  _  /              
     \  /\  / / /   \ \ | . \  | |____| | \ \              
      \/  \/ /_/     \_\|_|\_\ |______|_|  \_\


```


#  The Ninth Walker - Alpha Version

**The Ninth Walker** é um RPG de aventura em texto desenvolvido em **C#** e **.NET**. O jogo foca em exploração de cenários, combate estratégico por turnos e progressão de personagem através de um sistema de itens e níveis.


---

##  Funcionalidades Atuais

* **Sistema de Combate:** Escolha entre Ataque Rápido, Golpe Pesado ou Fúria para derrotar inimigos.
* **Gestão de Inventário:** Sistema dinâmico que permite carregar poções e armas utilizando a classe `Items`.
* **Equipamentos:** Armas que influenciam diretamente o `DanoTotal` do herói.
* **Sistema de Loot:** Inimigos possuem chances de drop de itens consumíveis e **armas raras** (10% de chance).
* **Progressão (Level Up):** Ganho de XP, aumento de atributos (Vida e Ataque) e expansão de energia para golpes especiais a cada nível alcançado.
* **Exploração:** Três biomas iniciais com dificuldades progressivas:
    1.  **Floresta Sombria** (Fácil)
    2.  **Caverna de Gelo** (Médio)
    3.  **Castelo Abandonado** (Difícil)

---

##  Estrutura do Projeto

O projeto segue uma arquitetura separada por responsabilidades para facilitar a manutenção e expansão:

* **`Core/Models`**: Contém as classes base do jogo.
    * `Heroi.cs`: Gerencia status, inventário e ações do jogador.
    * `Inimigo.cs`: Define os monstros e a lógica de recompensas (Loot Table).
    * `Items.cs`: Define as propriedades de armas e consumíveis (Nome, Poder, Raridade).
* **`API/Program.cs`**: O orquestrador principal que gerencia os menus e o fluxo da aventura.

---

##  Como Jogar

### Pré-requisitos
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download) ou superior instalado.

### Execução
1. Clone o repositório.
2. Navegue até a pasta do projeto via terminal:
   ```bash
   cd src/api
