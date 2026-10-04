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

        try {
            $statement->execute([
                'firstName' => $data['FirstName'],
                'lastName' => $data['LastName'],
                'email' => $data['Email'],
                'entryDate' => $data['EntryDate'],
                'departmentId' => $data['DepartmentId'],
            ]);
        } catch (PDOException $exception) {
            if ($this->isDuplicateEmail($exception)) {
                throw new DuplicateEmailException();
            }

            throw $exception;
        }
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

        try {
            $statement->execute([
                'firstName' => $data['FirstName'],
                'lastName' => $data['LastName'],
                'email' => $data['Email'],
                'entryDate' => $data['EntryDate'],
                'departmentId' => $data['DepartmentId'],
                'id' => $id,
            ]);
        } catch (PDOException $exception) {
            if ($this->isDuplicateEmail($exception)) {
                throw new DuplicateEmailException();
            }

            throw $exception;
        }
    }

    public function delete(int $id): void
    {
        $sql = 'DELETE FROM dbo.Employee WHERE Id = :id';

        $statement = $this->pdo->prepare($sql);
        $statement->execute(['id' => $id]);
    }

    private function isDuplicateEmail(PDOException $exception): bool
    {
        $sqlServerErrorCode = $exception->errorInfo[1] ?? null;
        $message = $exception->errorInfo[2] ?? '';

        return in_array($sqlServerErrorCode, [2627, 2601], true)
            && str_contains($message, 'UQ_Employee_Email');
    }
}
