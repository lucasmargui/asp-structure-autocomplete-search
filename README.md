<H1 align="center">Estrutura Campo Autocomplete</H1>
<p align="center">🚀 Projeto de criação de uma estrutura utilizando um campo de autocomplete para referências futuras</p>

## Recursos Utilizados

* Jquery-easy-autocomplete
* Entity Framework

 ## Execução do Entity Framework nas IDE's: VS 2015/2017:

 <details>
  <summary>Clique para mostrar conteúdo</summary>
  
 
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

</details>


## Controller

<details>
  <summary>Clique para mostrar conteúdo</summary>
  
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


</details>



## Scripts

<details>
  <summary>Clique para mostrar conteúdo</summary>
  

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


</details>

## Resultado

<div align="center">
<img src="https://github.com/lucasmargui/ASP_Campo_Autocomplete/assets/157809964/3093771a-a72d-43e9-9929-a149d654ab91" style="width:100%">
</div>





