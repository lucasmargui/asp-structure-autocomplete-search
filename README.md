<H1 align="center">Autocomplete Field Structure</H1>
<p align="center">🚀 Project to create a structure using an autocomplete field for future references</p>

## Resources Used

* jquery-easy-autocomplete
* Entity Framework


<div align="center">
<img src="https://github.com/lucasmargui/ASP_Campo_Autocomplete/assets/157809964/3093771a-a72d-43e9-9929-a149d654ab91" style="width:70%">
</div>

  ## Entity Framework execution in IDE's: VS 2015/2017:

  <details>
   <summary>Click to show content</summary>
  
 
  When executing the commands:
 
   ```
     Enable-Migrations
   ```
   It is
  
   ```
     Update-Database -Verbose
   ```
  
In the most recent versions of Visual Studio (2015/2017), it is necessary to create a new instance of sql localdb on your computer. Which can be created in the following way:

Step 1: Open cmd and execute the following command:
   ```
   SqlLocalDB.exe create "Local"
   ```
Step 2: Run the instance with the following command:
   ```
   SqlLocalDb.exe start
   ```
  
Step 3: Go to the 'Package Manager Console' and execute the following command:
   ```
   Update-Database -Verbose
   ```

## Changing the connection string

Configure connectionStrings with local database where 'name' will be used as a reference for connecting to Entity Framework
```
Web.Config
```
```
<connectionStrings>
<add name="DbAutocomplete" connectionString="Data Source= (localdb)\Local;Initial Catalog=DbAutocomplete;Integrated Security=True;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

</details>


## Controller

<details>
   <summary>Click to show content</summary>
  
### CitiesController

```
Controller/CitiesController.cs
```

Returns a Json with data from the cities corresponding to the selected district

```
var db = new ClientesContext();
             var cities = db.Cities
                             .Where(c => c.UF == uf)
                             .Select(c => new { Id = c.Id, Name = c.Name });
             return Json(cities, JsonRequestBehavior.AllowGet);
```


</details>



## Scripts

<details>
   <summary>Click to show content</summary>
  

```
Scripts/umd/autocomplete-cidades.js
```

Through ListarCidadesPorUF through the GET method of CidadesController returns a JsonResult with the data from the corresponding table with UF

```
return "/Cities/ListCitiesByUF?uf=" + uf;

```

Uses easycomplete from jquery-easy-autocomplete to display the data
```
    $("#txt-cidade").easyAutocomplete(options);
```


</details>

