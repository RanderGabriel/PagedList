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
   "pageOptions":{  
      "pageNumber":5,
      "pageSize":10,
      "itemCount":347,
      "pageCount":35
   },
   "urlNavigator":{  
      "navigatorSize":null,
      "firstPage":{  
         "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=1",
         "pageNumber":1,
         "isCurrent":false
      },
      "previousPage":{  
         "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=4",
         "pageNumber":4,
         "isCurrent":false
      },
      "currentPage":{  
         "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=5",
         "pageNumber":5,
         "isCurrent":true
      },
      "nextPage":{  
         "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=6",
         "pageNumber":6,
         "isCurrent":false
      },
      "lastPage":{  
         "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=35",
         "pageNumber":35,
         "isCurrent":false
      },
      "numericPages":null
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
   "pageOptions":{  
      "pageNumber":5,
      "pageSize":10,
      "itemCount":347,
      "pageCount":35
   },
   "urlNavigator":{  
      "navigatorSize":10,
      "firstPage":{  
         "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=1",
         "pageNumber":1,
         "isCurrent":false
      },
      "previousPage":{  
         "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=4",
         "pageNumber":4,
         "isCurrent":false
      },
      "currentPage":{  
         "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=5",
         "pageNumber":5,
         "isCurrent":true
      },
      "nextPage":{  
         "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=6",
         "pageNumber":6,
         "isCurrent":false
      },
      "lastPage":{  
         "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=35",
         "pageNumber":35,
         "isCurrent":false
      },
      "numericPages":[  
         {  
            "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=1",
            "pageNumber":1,
            "isCurrent":false
         },
         {  
            "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=2",
            "pageNumber":2,
            "isCurrent":false
         },
         {  
            "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=3",
            "pageNumber":3,
            "isCurrent":false
         },
         {  
            "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=4",
            "pageNumber":4,
            "isCurrent":false
         },
         {  
            "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=5",
            "pageNumber":5,
            "isCurrent":true
         },
         {  
            "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=6",
            "pageNumber":6,
            "isCurrent":false
         },
         {  
            "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=7",
            "pageNumber":7,
            "isCurrent":false
         },
         {  
            "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=8",
            "pageNumber":8,
            "isCurrent":false
         },
         {  
            "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=9",
            "pageNumber":9,
            "isCurrent":false
         },
         {  
            "pageUrl":"http://www.meusite.com/listagem?filtroA=xyz&filtroB=123&pageSize=10&pageNumber=10",
            "pageNumber":10,
            "isCurrent":false
         }
      ]
   }
}
```
