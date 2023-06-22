СТРОКА ПОДКЛЮЧЕНИЯ
- Строка подключения перенесена из appsettings.json в переменные окружения
- Переменные окружения находятся по пути "Project CRM -> Project Properties -> Debug -> Debug launch profiles UI -> Environment Variables"
- Наименование переменной "POSTGRESQL_CONNECTION_STRING", значение вида "Server/=localhost;Port/=****;Userid/=****;Password/=****;Pooling/=false;Timeout/=15;Database/=CRMDb", подставив соответствующие значения параметров подключения
- Перед применением миграции на БД (update-database) необходимо в Package Manager Console (PMC) ввести команду $env:POSTGRESQL_CONNECTION_STRING='Server=localhost;Port=****;Userid=****;Password=****;Pooling=false;Timeout=15;Database=CRMDb', подставив соответствующие значения параметров подключения

СТРУКТУРА ПРОЕКТА ВЕТКИ dev_excel_part2
- Controllers
	* ExcelController - основной контроллер для импорта файлов Excel, содержит единственный метод (точку входа)
- Data
	* ApplicationDbContext - содержит описание контекста работы с БД, контекстов сущностей и уникальности сущностей по определенным атрибутам
- Migrations
	* Папка, содержащая миграции БД
- Model
	* DTO - описание сущности (класса) DTO, формируемой в результате парсинга файла Excel
	* Entities - описание основных сущностей (классов) проекта, которые формируются в результате маппинга из главной сущности (класса) DTO
- Services
	* DTO - сервис-реализация интерфейса "ICompanyExcelDTOService"
	* Entities - сервисы-реализации интерфейсов для работы с основными сущностями проекта (не DTO)
	* Helpers - описание вспомогательных сущностей, описывающих результаты импорта файлов Excel, а также ошибки импорта
	* Interfaces - интерфейсы, описывающие основные методы для работы с сущностями проекта
	* Repositories - интерфейсы и сервисы репозиториев, описывающие основные методы для создания и сохранения основных сущностей проекта в БД