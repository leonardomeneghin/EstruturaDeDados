
# DDD
1. Reason for the software exists
	EX.: DataStructures -> Can be a package (module).
	Each internal module, must to follow this design.

2. Domainx expert
	Oferece um conhecimento do negócio, e por consequência, reflete o domínio.
	É importante implementar a solução de problemas em linguagem ubíqua, pois dessa forma, programadores e POs conseguem estruturar o software juntos.

3. Domain Model (É um documento, não artefato)
	Modelo de domínio deve guardar:
		- conhecimento estruturado do problema
		- Vocabulário e conceitos chave do domínio
		- Identifica relacionamento entre todas as entidades
		- ferramenta de comunicação junto com a linguagem ubíqua.
	Assim, ela deve representar claramente o problema, geralmente expresso por diagramas ou documento.

4. Domain Service (É um artefato)
	Estrutura sem estado que oferece o comportamento do mundo real
	Relevante apenas para a lógica do negócio, não deve entrar em contato com detalhes técnicos.
	(Falar de tomadores por exemplo, faz sentido aqui, mas não faz sentido falar de bytes do nome do tomador)

5. Anticorrupção (É um artefato)
	Camada de proteção que protege o domínio de conceitos que não fazem parte do próprio domínio.
	Aqui é representado as dependências de microserviços ou serviços externos, dessa forma permite modularizar o software.
	Ou seja:
	- Intermediador
	- Serve para que ambos os sistemas troquem dados sem que um dependa da implementação e do contexto do outro.

6. Arquitetura Final
	Sempre é interessante separar o software em:
		- User interface (UI) -> Usuário preenche e interage
		- AntiCorrupção (Application) -> Irá intermediar outras implementações, assegurança a separãção do domínio. Nao guarda informações do domínio.
		- Domínio + Factories -> Possui as regras de negócio, sendo essa sua única preocupação.
		- Domain Model (Entities)

Em microservices, isso vira algo do tipo>
	- Controller (expor a "api", seria algo no papel de "UI")
	- Methods ou Service(Interfaces, métodos, coisas técnicas e gestão da integração, etc)
	- Business (layer)
	_ Repository
	- Entities, agregattes and VOs.
	Eu iria um pouco além e criaria outro domínio:
	- Integrations (AntiCorruption) intermediando Controller -> Methods + Integrations -> Business -> Repository (que possui as entities)

Em desenvolvimento de jogos, seria algo do tipo:
	O DDD está basicamente dentro de Handlers
	- Prefabs (Objetos de arte e modelos criados para o game)
	- Handlers (Contexto que segura toda a lógica de componentes)
		- GameHandler (Opera no contexto de um sistema)
			(LifeManager)
			(Actors) (Player, IA, etc)
		
		- DataAccess (Define o contexto da conexão ao banco)
		- Models (Mapeamentos de banco, etc)
		- Entities (Define os objetos do jogo, como armazenar, etc)
		- Repository (Realiza as operações de banco)
	- Assets
		- Animations
		- Pictures
		- Songs
		- Actors
		


