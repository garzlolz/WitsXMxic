## MVC 版本

### 1. 修改 appsettings.json 中的連線字串

修改 appsettings.Development.json 中的連線字串或是加入 appsettings.json

- 位置 `Project/MVC/appsettings.Development.json`

```
  "ConnectionStrings": {
    "WitsXMxic": "Server={Your DB Host};TrustServerCertificate=True;Database=WitsXMxic;User ID={Acccount Id};Password={Account Password};"
  }
```

### 2. 加入 DB 結構

1. 執行 WitsXMxic.sql，位置 ` Project/WitsXMxic.sql`

2. 或使用 Code First 指令

```
Nuget> Update-Dabase
```

(1 或 2 則一使用)

### 3. 於 VS 中執行

- 列表頁
  ![alt text](https://i.imgur.com/Z5dUalU.jpg)

- 新增及編輯頁
  ![alt text](https://i.imgur.com/cunPRRr.jpeg)

## WWebForm 版本

### 1. 修改 Web.config 中的連線字串

修改 Web.config 中的連線字串

- 位置 `Project\WebForm\WitsXMxic_WebFormVersion\Web.config`

```
  <connectionStrings>
    <add name="WitsXMxicEntities" connectionString="metadata=res://*/DBModels.WitsXMxicDB.csdl|res://*/DBModels.WitsXMxicDB.ssdl|res://*/DBModels.WitsXMxicDB.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source={Your Host};initial catalog=WitsXMxic;persist security info=True;user id={DB Acount};password={DB Password};trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
```

### 2. 加入 DB 結構

- 執行 WitsXMxic.sql，位置 ` Project/WitsXMxic.sql`

(1 或 2 則一使用)

### 3. 於 VS 中執行

- 列表頁
  ![alt text](https://i.imgur.com/WPqhOAe.png)
  ###
- 新增頁
  ![alt text](https://i.imgur.com/MxMxL0P.png)
  ###
- 編輯頁
  ![alt text](https://i.imgur.com/hxahNVC.png)
