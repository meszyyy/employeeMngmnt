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

    public function getDepartments(): array
    {
        $sql = 'SELECT Id, Name FROM dbo.Department ORDER BY Name';
        return $this->pdo->query($sql)->fetchAll();
    }

    public function getById(int $id): ?array
    {
        $sql = '
            SELECT e.Id, e.FirstName, e.LastName, e.Email, e.EntryDate, e.DepartmentId, d.Name AS DepartmentName
            FROM dbo.Employee e
            JOIN dbo.Department d ON e.DepartmentId = d.Id
            WHERE e.Id = :id
        ';

        $statement = $this->pdo->prepare($sql);
        $statement->execute(['id' => $id]);

        return $statement->fetch() ?: null;
    }

    public function create(array $data): void
    {
        $sql = '
            INSERT INTO dbo.Employee (FirstName, LastName, Email, EntryDate, DepartmentId)
            VALUES (:firstName, :lastName, :email, :entryDate, :departmentId)
        ';

        $statement = $this->pdo->prepare($sql);
        $statement->execute([
            'firstName' => $data['FirstName'],
            'lastName' => $data['LastName'],
            'email' => $data['Email'],
            'entryDate' => $data['EntryDate'],
            'departmentId' => $data['DepartmentId']
        ]);
    }

    public function update(int $id, array $data): void
    {
        $sql = '
            UPDATE dbo.Employee
            SET FirstName = :firstName,
            LastName = :lastName,
            Email = :email,
            EntryDate = :entryDate,
            DepartmentId = :departmentId
            WHERE Id = :id
        ';

        $statement = $this->pdo->prepare($sql);
        $statement->execute([
            'firstName' => $data['FirstName'],
            'lastName' => $data['LastName'],
            'email' => $data['Email'],
            'entryDate' => $data['EntryDate'],
            'departmentId' => $data['DepartmentId'],
            'id' => $id
        ]);
    }
}
