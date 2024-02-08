<H1 align="center">Estrutura Campo Autocomplete</H1>
<p align="center">🚀 Projeto de criação de uma estrutura utilizando um campo de autocomplete para referências futuras</p>

## Recursos Utilizados

* Jquery-easy-autocomplete
* Entity Framework

 ## Execução do Entity Framework nas IDE's: VS 2015/2017:
 
 Ao realizar os comandos:
 
  ```
    Enable-Migrations
  ```
  e
  
  ```
    Update-Database -Verbose
  ```
  
Nas versões mais recentes do Visual Studio (2015/2017), se faz necessário criar uma nova instância do localdb do sql no seu computador. A qual poderá ser criado da seguinte maneira:

Passo 1: Abrir o cmd e executar o seguinte comando:
  ```
  SqlLocalDB.exe create "Local"
  ```
Passo 2: Executar a instance com seguinte comando:
  ```
  SqlLocalDb.exe start
  ```
  
Passo 3: Ir até o 'Package Manager Console' e executar o seguinte comando:
  ```
  Update-Database -Verbose
  ```

## Alteração da String de conexão

Configurar a connectionStrings com banco de dados local onde 'name' será utilizado como referência para conexão com Entity Framework
```
Web.Config
```
```
<connectionStrings>
<add name="DbAutocomplete" connectionString="Data Source= (localdb)\Local;Initial Catalog=DbAutocomplete;Integrated Security=True;"  providerName="System.Data.SqlClient" />
</connectionStrings>
```

## Controller

### CidadesController

```
Controller/CidadesController.cs
```

Retorna um Json com dados das cidades correspondentes ao distrito selecionado

```
var db = new ClientesContext();
            var cidades = db.Cidades
                            .Where(c => c.UF == uf)
                            .Select(c => new { Id = c.Id, Nome = c.Nome });
            return Json(cidades, JsonRequestBehavior.AllowGet);
```

## Scripts

```
Scripts/umd/autocomplete-cidades.js
```

Através de ListarCidadesPorUF pelo método GET de CidadesController retorna um JsonResult com os dados da tabela correspondente com UF

```
return "/Cidades/ListarCidadesPorUF?uf=" + uf;

```

Utiliza easycomplete de jquery-easy-autocomplete para exibir os dados
```
   $("#txt-cidade").easyAutocomplete(options);
```

## Resultado

<img src="https://cdn.discordapp.com/attachments/1046824853015113789/1204509983593726043/image.png?ex=65d4fe56&is=65c28956&hm=851a07fe3bd365686e23b9fe99e67887a7b260baedb825761b4718a05f12320f&" alt="">



