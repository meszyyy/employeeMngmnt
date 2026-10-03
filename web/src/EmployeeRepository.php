<?php

declare(strict_types=1);

class EmployeeRepository
{
    public function __construct(private PDO $pdo)
    {
    }

    public function getAll(): array
    {
        $sql = '
            SELECT e.Id, e.FirstName, e.LastName, e.Email, e.EntryDate, e.DepartmentId, d.Name AS DepartmentName
            FROM dbo.Employee e
            JOIN dbo.Department d ON e.DepartmentId = d.Id
            ORDER BY e.LastName, e.FirstName
        ';

        return $this->pdo->query($sql)->fetchAll();
    }
}
