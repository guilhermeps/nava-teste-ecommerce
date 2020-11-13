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

# Payloads
Para executar os endpoints temos os seguintes payloads de exemplo:

* Criar uma venda
```
curl -X POST \
  http://{host da api}/api/vendas \
  -H 'cache-control: no-cache' \
  -H 'content-type: application/json' \
  -H 'postman-token: 81cacadf-f405-649d-332d-3046035c99de' \
  -d '{
	"cpf": "09189796683",
	"nome": "Guilherme",
	"email": "guilherme@teste.com",
	"telefone": "31994237405",
	"itens": ["geladeira", "fogão"]
}
'
```

* Buscar uma venda
O `idVenda` pode ser obtido no header location da resposta do enpoint de criação de venda.
```
curl -X GET \
  http://{host da api}/api/vendas/{idVenda} \
  -H 'cache-control: no-cache' \
  -H 'postman-token: cc14e127-b8bb-d20b-7475-6d96ae4cb249'
```

* Atualizar o status da venda

curl -X PATCH \
  http://{host da api}/api/vendas/{idVenda} \
  -H 'cache-control: no-cache' \
  -H 'content-type: application/json' \
  -H 'postman-token: 308ea461-d2fe-8255-4097-8020abee69ce' \
  -d '{
	"status": "pagamento aprovado"
}'

```