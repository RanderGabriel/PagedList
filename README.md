# PagedList 

Lista paginada em C# para aplicações .NET.

# Utilização com navegação básica

## Construíndo objeto de paginação

Para recuperar dados de paginação com navegação básica:

```csharp

// Total de itens existentes para paginar
string originUrl = "http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=5";

// Total de itens existentes para paginar
int itemCount = 347;

// Total de itens por página
int pageSize = 10;

// Total de itens por página
int pageNumber = 5;

// Cria objeto de paginação
PagedList pagedList = new PagedList(originUrl, itemCount, pageNumber, pageSize);

```

## Estrutura do objeto construído

Um exemplo do objeto obtido no exemplo acima (convertido em *JSON* para melhor visualizar a sua estrutura).

```json
{
	"options" : {
		"pageNumber" : 5,
		"pageSize" : 10,
		"itemCount" : 347,
		"pageCount" : 35
	},
	"navigator" : {
		"navigatorSize" : null,
		"first" : {
			"url" : "http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=1",
			"number" : 1
		},
		"previous" : {
			"url" : "http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=4",
			"number" : 4
		},
		"next" : {
			"url" : "http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=6",
			"number" : 6
		},
		"last" : {
			"url" : "http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=35",
			"number" : 35
		},
		"numerics" : null
	}
}
```

# Utilização com navegação básica e numérica

## Construíndo objeto de paginação

Para recuperar dados de paginação com navegação básica e numérica:

```csharp

// Total de itens existentes para paginar
string originUrl = "http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=5";

// Total de itens existentes para paginar
int itemCount = 347;

// Total de itens por página
int pageSize = 10;

// Total de itens por página
int pageNumber = 5;

// Total de itens no navegador de páginas numéricas
int navigatorSize = 10;

// Cria objeto de paginação
PagedList pagedList = new PagedList(originUrl, itemCount, pageNumber, pageSize, navigatorSize);

```

## Estrutura do objeto construído

Um exemplo do objeto obtido no exemplo acima (convertido em *JSON* para melhor visualizar a sua estrutura):

```json
{  
   "options":{  
      "pageNumber":5,
      "pageSize":10,
      "itemCount":347,
      "pageCount":35
   },
   "navigator":{  
      "navigatorSize":10,
      "first":{  
         "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=1",
         "number":1
      },
      "previous":{  
         "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=4",
         "number":4
      },
      "next":{  
         "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=6",
         "number":6
      },
      "last":{  
         "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=35",
         "number":35
      },
      "numerics":[  
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=1",
            "number":1
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=2",
            "number":2
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=3",
            "number":3
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=4",
            "number":4
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=5",
            "number":5
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=6",
            "number":6
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=7",
            "number":7
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=8",
            "number":8
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=9",
            "number":9
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=10",
            "number":10
         }
      ]
   }
}
```

# Exemplos de algumas possíveis respostas

Estes exemplos possuem navegador numérico com tamanho 3.

## Página atual é a primeira

```json
{  
   "options":{  
      "pageNumber":1,
      "pageSize":10,
      "itemCount":347,
      "pageCount":35
   },
   "navigator":{  
      "navigatorSize":3,
      "first":null,
      "previous":null,
      "next":{  
         "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=2",
         "number":2
      },
      "last":{  
         "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=35",
         "number":35
      },
      "numerics":[  
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=1",
            "number":1
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=2",
            "number":2
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=3",
            "number":3
         }
      ]
   }
}
```
## Página atual é a última

```json
{  
   "options":{  
      "pageNumber":35,
      "pageSize":10,
      "itemCount":347,
      "pageCount":35
   },
   "navigator":{  
      "navigatorSize":3,
      "first":{  
         "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=1",
         "number":1
      },
      "previous":{  
         "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=34",
         "number":34
      },
      "next":null,
      "last":null,
      "numerics":[  
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=33",
            "number":33
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=34",
            "number":34
         },
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=35",
            "number":35
         }
      ]
   }
}
```

## Única página

```json
{  
   "options":{  
      "pageNumber":1,
      "pageSize":10,
      "itemCount":10,
      "pageCount":1
   },
   "navigator":{  
      "navigatorSize":3,
      "first":null,
      "previous":null,
      "next":null,
      "last":null,
      "numerics":[  
         {  
            "url":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=1",
            "number":1
         }
      ]
   }
}
```

## Nenhum item para exibir

```json
{  
   "options":{  
      "pageNumber":1,
      "pageSize":10,
      "itemCount":0,
      "pageCount":0
   },
   "navigator":{  
      "navigatorSize":3,
      "first":null,
      "previous":null,
      "next":null,
      "last":null,
      "numerics":null
   }
}
```
