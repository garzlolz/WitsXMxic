### 1. 修改 appsettings.json 中的連線字串

修改 appsettings.Development.json 中的連線字串或是加入 appsettings.json

```
  "ConnectionStrings": {
    "WitsXMxic": "Server={Your DB Host};TrustServerCertificate=True;Database=WitsXMxic;User ID={Acccount Id};Password={Account Password};"
  }
```

### 2. 加入 DB 結構

- 1.執行 WitsXMxic.sql 或使用 Code First 指令

```
Nuget> Update-Dabase
```

### 3. 於 VS 中執行

- 列表頁
  ![alt text](https://i.imgur.com/Z5dUalU.jpg)

- 新增及編輯頁
  ![alt text](https://i.imgur.com/cunPRRr.jpeg)
