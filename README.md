# Employee Management

A small employee management system made of two separate apps
that share one SQL Server database.

- `desktop/` - Windows Forms app (C#, .NET 10)
- `web/` - web app in plain PHP
- `database/` - SQL script that creates the tables and some sample data

Both apps can list, add, edit and delete employees (first name, last name,
e-mail, department, date of entry).

## Requirements

What I used for development and testing:

- Windows 11
- SQL Server 2025 LocalDB
- .NET 10 SDK
- PHP 8.5.11 (ZTS, x64) with the `pdo_sqlsrv` extension
- Microsoft ODBC Driver 17 for SQL Server

## Database

Run the script with sqlcmd:

```
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -f 65001 -i database\schema.sql
```

or open `database/schema.sql` in SSMS and execute it.

`-f 65001` tells sqlcmd that the file is UTF-8, otherwise names like "Müller"
or "Weiß" are not imported correctly.

The script creates the `EmployeeManagement` database if it does not exist yet.
It drops and recreates the tables, so running it again resets everything to the
sample data.

Both apps connect with Windows authentication. To use a SQL login instead, add
`User Id=...;Password=...` to the connection string of the desktop app and set
`username` / `password` in the web app's `config.php`.

## Desktop app

The connection string is in
`desktop/EmployeeManagement.WinForms/appsettings.json`.

Open `desktop/EmployeeManagement.slnx` in Visual Studio and press F5.

The solution has three projects:

- **Core** - the `Employee` / `Department` models, the repository interfaces
  and a `DuplicateEmailException`
- **Data** - repository implementations with Dapper
- **WinForms** - the UI; the forms only know the interfaces from Core, the
  concrete repositories are created in `Program.cs`

Double-click a row to edit it.

## Web app

1. Copy the example config and adjust the DSN if needed:

   ```
   copy web\config.example.php web\config.php
   ```

2. Make sure `php.ini` loads the SQL Server driver and mbstring:

   ```
   extension=mbstring
   extension=pdo_sqlsrv_85_ts_x64
   ```

   The name of the driver DLL depends on the PHP version and on whether PHP is
   thread safe (ts) or not (nts). `php -m` should list `pdo_sqlsrv`.

3. Start PHP's built-in web server:

   ```
   php -S localhost:8000 -t web/public
   ```

4. Open http://localhost:8000

Only `web/public` is reachable from the browser. The classes (`web/src`), the
templates and the config file are outside of it.

## Notes on some decisions

- **Departments are a separate table.** This way the department is picked from
  a list instead of typed in. The foreign key uses `ON DELETE NO ACTION`, so a
  department that still has employees cannot be deleted.
- **The date of entry is a `DATE`**, not a `DATETIME`. It is a calendar day, a
  time part would only cause problems when comparing values.
- **E-mail addresses are unique** (unique constraint in the database). I don't
  check this with a SELECT before saving, because another user could insert the
  same address in the meantime. Instead both apps catch the constraint error
  (SQL Server error 2627/2601) and show "This e-mail address is already in use"
  next to the field.
- **Validation happens in both apps** before saving: required fields, valid
  e-mail address, valid date. In the web app the browser checks are only for
  convenience, the PHP validation is what counts.
- **The PHP app is intentionally simple.** No framework, no router, no
  Composer: two pages (`index.php`, `edit.php`) plus `delete.php`, and the logic
  in three small classes. All SQL is in `EmployeeRepository`, the rows are plain
  arrays. For an app of this size I found that easier to follow than a full MVC
  setup.
- **Web security basics:** prepared statements everywhere, every output goes
  through `htmlspecialchars`, deleting only works with POST (with a
  confirmation), and after saving the page redirects (Post/Redirect/Get), so a
  browser refresh does not submit the form twice.
- **Desktop app:** database calls are async so the window does not freeze, and
  the buttons are disabled while saving, so a double click cannot save twice.

## Known limitations / what I would do next

- No login or user permissions.
- No CSRF protection on the web forms yet.
- No paging or search; with a lot of employees the list would need it.
- No automated tests.
- The desktop app still shows the technical exception message when the database
  is not reachable. It should show a short, user-friendly message and write the
  details to a log instead.
