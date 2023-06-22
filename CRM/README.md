������ �����������
- ������ ����������� ���������� �� appsettings.json � ���������� ���������
- ���������� ��������� ��������� �� ���� "Project CRM -> Project Properties -> Debug -> Debug launch profiles UI -> Environment Variables"
- ������������ ���������� "POSTGRESQL_CONNECTION_STRING", �������� ���� "Server/=localhost;Port/=****;Userid/=****;Password/=****;Pooling/=false;Timeout/=15;Database/=CRMDb", ��������� ��������������� �������� ���������� �����������
- ����� ����������� �������� �� �� (update-database) ���������� � Package Manager Console (PMC) ������ ������� $env:POSTGRESQL_CONNECTION_STRING='Server=localhost;Port=****;Userid=****;Password=****;Pooling=false;Timeout=15;Database=CRMDb', ��������� ��������������� �������� ���������� �����������

��������� ������� ����� dev_excel_part2
- Controllers
	* ExcelController - �������� ���������� ��� ������� ������ Excel, �������� ������������ ����� (����� �����)
- Data
	* ApplicationDbContext - �������� �������� ��������� ������ � ��, ���������� ��������� � ������������ ��������� �� ������������ ���������
- Migrations
	* �����, ���������� �������� ��
- Model
	* DTO - �������� �������� (������) DTO, ����������� � ���������� �������� ����� Excel
	* Entities - �������� �������� ��������� (�������) �������, ������� ����������� � ���������� �������� �� ������� �������� (������) DTO
- Services
	* DTO - ������-���������� ���������� "ICompanyExcelDTOService"
	* Entities - �������-���������� ����������� ��� ������ � ��������� ���������� ������� (�� DTO)
	* Helpers - �������� ��������������� ���������, ����������� ���������� ������� ������ Excel, � ����� ������ �������
	* Interfaces - ����������, ����������� �������� ������ ��� ������ � ���������� �������
	* Repositories - ���������� � ������� ������������, ����������� �������� ������ ��� �������� � ���������� �������� ��������� ������� � ��