# Processo seletivo Nava

Desafio técnico do processo seletivo da Nava. Contempla o desenvolvimento de API com operações que fazem referência a um sistema de e-commerce. Tem como premissa o seguinte: 
 Construir uma API utilizando .net core 3.1.

·  A API deve possuir 3 operações: 

Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento". 

Buscar venda: Busca pelo Id da venda.

Atualizar venda: Permite que seja atualizado o status da venda (possíveis status: “Pagamento aprovado” | “Enviado para transportadora” | “Entregue” | “Cancelada”)

·  Uma venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos.

·  O vendedor deve possuir id, cpf, nome, e-mail e telefone.

·  A inclusão de uma venda deve possuir pelo menos 1 item.

·  A atualização de status deve permitir somente as seguintes transições:

De: “Aguardando pagamento.” Para: “Pagamento Aprovado“

De: “Aguardando pagamento. “ Para: “Cancelada“

De: “Pagamento Aprovado. “ Para: “Enviado para Transportadora“

De: “Pagamento Aprovado. “ Para: “Cancelada“

De: “Enviado para Transportador“. Para: Entregue

·  A API não precisa ter mecanismos de autenticação/autorização.

·  A aplicação não precisa implementar os mecanismos de persistência em um banco de dados, eles podem ser persistidos "in memory" (ex.: Entity framework in memory), e devem ser representados por interfaces

# Considerações
Para oferecer uma melhor amostragem das minhas habilidades técnicas implementei o padrão de projeto *Ports and Adapters* aplicando este padrão nos princípios do *Clean Architecture*. O código foi desenvolvido observando os princípios do *SOLID*.

No que tange aos testes automatizados busquei passar pelas camadas de Unidade, Componentes e Integração. Como se trata de uma amostragem não me preocupei em cobrir a API em 100%, muito embora o faria em uma situação real. Vale ressaltar também que várias validações não foram feitas nas entidades, pois traria mais complexidade para este desafio, e entendo que não é esse o objetivo principal nesta fase.