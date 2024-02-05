### 1. 修改 appsettings.json 中的連線字串

修改appsettings.Development.json中的連線字串或是加入appsettings.json
```
  "ConnectionStrings": {
    "WitsXMxic": "Server={Your DB Host};TrustServerCertificate=True;Database=WitsXMxic;User ID={Acccount Id};Password={Account Password};"
  }
```

### 2. 加入DB結構

- 1.執行WitsXMxic.sql或使用Code First 指令
```
Nuget> Update-Dabase
```

### 3. 於VS中執行