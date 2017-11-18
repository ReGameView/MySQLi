# MySQLi
Библиотека для подключение и запросов на C# [SQLite]

* Имеет на момент тестирование 1 функцию и конструктор
## Конструктор()
Выполняет подключение к базе данных
Достаточно просто объявить объект в любом удобном месте кода (Желательно объявить глобальной)
```C#
//it's C#
MySQLi sql = new MySQLi();
``` 

## query(string)
Выполняет запрос на подключение к базе данных
**Возращает:** SQLiteDataAdapter
```C#
SQLiteDataAdapter adapter = sql.query("SELECT * FROM `example`;");
foreach(DbDataRecord record in adapter)
{
  textBox1.Text = record['id'];
  textBox2.Text = record['name'];
}
```
