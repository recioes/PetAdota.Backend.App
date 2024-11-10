<h1 align="center">PetAdota Backend API 🐾</h1>

<p align="center">
O projeto "PetAdota Backend API" é uma aplicação desenvolvida em C#, para a matéria de Programação Orientada a Objetos III de minha faculdade, que oferece uma API RESTful para gerenciar a adoção de animais. Esta API é responsável por operações CRUD, como criação, atualização, listagem e exclusão de registros de animais, conectando-se a um banco de dados MongoDB. O backend segue uma arquitetura em camadas, separando a lógica de negócio da infraestrutura de dados.
</p>

<p align="center">
  <a href="#-tecnologias">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-estrutura-do-projeto">Estrutura do Projeto</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
   <a href="#-configurações">Configurações</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-design-da-aplicação">Design da Aplicação</a>
</p>

<br>

## 🚀 Tecnologias

<p>Esse projeto foi desenvolvido com as seguintes tecnologias:</p>

<ul>
  <li>C#</li>
  <li>ASP.NET Core</li>
  <li>MongoDB</li>
  <li>Swagger para documentação da API</li>
  <li>Git e GitHub para controle de versão</li>
</ul>

## 💻 Estrutura do Projeto

<p>A solução é organizada em três camadas principais:</p>

<ul>
  <li><b>API</b>: responsável pelas controllers, configuração do pipeline de middleware e injeção de dependências. Aqui estão as rotas que expõem as operações CRUD da API.</li>
  <li><b>Core</b>: esta camada contém os modelos de domínio, interfaces dos serviços, DTOs e a lógica de negócios. Todos os serviços são organizados aqui, seguindo os princípios de SOLID e desacoplamento.</li>
  <li><b>Infra</b>: implementa a infraestrutura do projeto, como as conexões ao banco de dados (MongoDB), repositórios e implementação das interfaces definidas no Core. Essa camada garante a persistência e recuperação dos dados.</li>
</ul>

<p>Cada camada é desacoplada das outras para facilitar manutenções, testes e futuras expansões.</p>

## ⚙️ Configurações

<ul>
  <li><b>Banco de Dados MongoDB</b>: Para utilizar este repositório, é necessário configurar um banco de dados MongoDB com uma collection apropriada para armazenar os dados dos animais. Certifique-se de que o banco e a collection estejam criados antes de executar a aplicação.</li>
  <li><b>Variáveis de Ambiente</b>: Configure as variáveis de ambiente no Windows para acessar a conexão com o MongoDB. As variáveis devem incluir pelo menos o nome do banco de dados e a string de conexão. Exemplo de variável:
    <ul>
      <li><code>Mongo_Animal_Db</code> - Nome do banco de dados MongoDB.</li>
      <li><code>Mongo_Connection_String</code> - String de conexão para o MongoDB.</li>
    </ul>
  </li>
  <li><b>Swagger</b>: A documentação da API pode ser acessada via <code>/swagger</code>, permitindo a fácil visualização e teste dos endpoints diretamente no navegador.</li>
</ul>

## 📚 Camadas do Projeto

### **Camada Infra**

<p>Implementa os repositórios que realizam a comunicação com o banco de dados MongoDB. Cada repositório implementa operações CRUD através de interfaces específicas que são consumidas pela camada de Core.</p>

### **Camada Core**

<ul>
  <li><b>Modelos e DTOs</b>: contém as definições das entidades que representam os dados dos animais para adoção. Os DTOs (Data Transfer Objects) garantem a transferência eficiente de dados entre o backend e o frontend.</li>
  <li><b>Serviços</b>: As regras de negócios são implementadas nos serviços, que seguem os princípios SOLID. Estes serviços são consumidos pelos controladores na camada <b>API</b>.</li>
  <li><b>Validators</b>: utiliza o FluentValidator para validar as entidades e os DTOs, garantindo que os dados atendam aos requisitos de negócio antes de serem processados. Essa validação inclui verificações de campos obrigatórios, tamanhos máximos de texto, formatos específicos e outras regras de negócio, proporcionando maior segurança e consistência nos dados.</li>
</ul>


### **Camada API**

<ul>
  <li><b>Controladores</b>: expondo os endpoints da API para gerenciar os dados dos animais. Controladores como <code>AnimalController</code> permitem a comunicação entre o cliente (frontend) e os dados do banco.</li>
  <li><b>Program e Middleware</b>: o ponto de entrada da aplicação está no arquivo <code>Program.cs</code>, e o middleware é configurado para tratar requisições e respostas HTTP.</li>
   <li><b>Extensions</b>: contém as configurações de injeção de dependência, que são registradas e chamadas no arquivo <code>Program.cs</code>.</li>
</ul>

## 🛠 Design da Aplicação

<p>O design da aplicação segue uma estrutura em camadas, onde a separação de responsabilidades é primordial. A camada <b>Core</b> lida com a lógica de negócios, enquanto a camada <b>Infra</b> gerencia a persistência e acesso a dados. Isso garante que o código seja modular e extensível, facilitando a manutenção e escalabilidade do sistema.</p>

<p>Ao rodar a aplicação, você pode testar os endpoints disponíveis através do Swagger, acessando <code>/swagger</code> no navegador. Isso facilita a exploração da API e o teste das operações CRUD.</p>
