# Inventory Management System

## Title and Description

**Inventory Management System** is a Windows Forms desktop application built using **C# (.NET)** and backed by **Oracle SQL**. It allows small businesses and shops to manage their stock, categories, and customer records through an intuitive and stylish graphical user interface.

---

## Acknowledgements

* **Oracle Database XE** for free database support
* **Bunifu UI Framework** for modern UI components
* **Microsoft Visual Studio** for a smooth development experience
* **GitHub** for version control and collaboration

---

## Appendix

* `FodyWeavers.xml`: Used for embedding dependencies
* `App.config`: Contains Oracle connection string
* `.csproj`: Manages dependencies through PackageReference

---

## Authors

* **Usama Akram**
  BSCS Student, FAST National University, Pakistan
  GitHub: [@usamacodez](https://github.com/usamacodez)

---

## Color Reference

* Primary Theme: `#3B82F6` (Blue)
* Sidebar BG: `#1F2937` (Dark Gray)
* Button Hover: `#60A5FA` (Light Blue)
* Status Texts: Green for success, Red for alert

---

## Contributing

Contributions are welcome! If you'd like to add a module, fix a bug, or improve UI:

1. Fork the repo
2. Create a feature branch
3. Commit and push
4. Open a pull request

---

## 🎥 Demo

*(Will add video or gif link here soon)*

---

## 🚁 Deployment

This is a desktop application and does not require deployment to a server. It can be compiled and run directly from Visual Studio or can be installed by created setup.

---

## 📄 Documentation

* Oracle DB setup queries in `/docs/oracle-schema.sql`
* UI structure described in `Forms/`
* App logic located in `InventoryManagementSystem/`

---

## Environment Variables

Oracle DB connection string is stored in `App.config`. Example:

```xml
<connectionStrings>
  <add name="OracleDbContext"
       connectionString="Data Source=localhost:1521/XEPDB1;User Id=your_user;Password=your_pass;"
       providerName="Oracle.ManagedDataAccess.Client" />
</connectionStrings>
```

---

## ❓ FAQ

**Q: Does this run on Linux?**
A: No, this project is built using Windows Forms, which is Windows-only.

**Q: Can I change the database to MySQL or SQL Server?**
A: Yes, but you’ll need to change the data access code and connection string.

---

## Features

* Login authentication
* Add/edit/delete Categories
* Add/edit/delete Customers
* Manage product inventory
* Display dashboards with stats
* Responsive UI with animations
* Database integration with Oracle

---

## Feedback

If you have any suggestions or feedback, feel free to reach out at:
**[usamacodez10@gmail.com](mailto:usamacodez10@gmail.com)**
Or open an issue in this repository.

---

## ⚖ Languages & Technologies used

* Languages: C#, SQL
* Tools: Visual Studio, Git, VS Code
* Frameworks: .NET
* DBMS: Oracle

---

## Installation

1. Clone the repo:

```bash
git clone https://github.com/usama-codez/inventory-management-system.git
```

2. Open the solution in Visual Studio
3. Restore NuGet packages
4. Run Oracle DB locally or connect to cloud
5. Update `App.config` with DB credentials
6. Press F5 to run the project

---

## Lessons

* Working with Oracle DB integration in C#
* Building layered desktop applications
* Using Fody for dependency management
* Creating modern Windows Forms UIs with Bunifu

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Logo

![icon](https://github.com/user-attachments/assets/7c6076b2-3abf-4227-9793-df78180ba798)

---

## Optimizations

* Switched from `packages/` to `PackageReference` for cleaner project structure
* Embedded DLLs using Costura.Fody to make a single-exe deployable app
* Lazy loading of forms to reduce memory footprint

---

## Roadmap

* [x] Basic Inventory CRUD
* [x] Oracle Integration
* [ ] Sales Module
* [ ] Expiry Date Notifications
* [ ] User Role Management
* [ ] MAUI mobile version (future)

---

## Run Locally

Make sure Oracle DB is running locally and that your Oracle listener is configured correctly. Update the config and run with F5 or from terminal:
Try Running this application on Visual Studio 2015 to avoid crashes and errors.

```bash
dotnet build
```

---

## Screenshots

*(Will add screenshots here soon...)*
---

## Support

For help or questions:

* Email: **[usamaakram.dev@gmail.com](mailto:usamaakram.dev@gmail.com)**
* GitHub Issues: [Create new issue](https://github.com/usama-codez/inventory-management-system/issues)

---

## Tech

* .NET Framework / .NET 6 (Windows Forms)
* Oracle SQL
* Bunifu UI Framework
* Fody & Costura
* Visual Studio 2015

---

## Running Tests

This project is UI-based and does not include automated unit tests. Manual testing was conducted per module.

---

## Usage / Examples

* Launch app
* Login using credentials
* Navigate sidebar to manage categories/customers/inventory
* Use dashboard to monitor stock levels
* Data is stored and retrieved via Oracle queries
  
```
```
