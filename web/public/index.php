<?php

declare(strict_types=1);

require_once __DIR__ . '/../bootstrap.php';

$employees = $employeeRepository->getAll();

require __DIR__ . '/../templates/header.php';
?>

<a href="edit.php" class="btn btn-primary mb-3">+ New</a>
<table class="table table-hover bg-white">
    <thead>
        <tr>
            <th>First name</th>
            <th>Last name</th>
            <th>E-mail</th>
            <th>Department</th>
            <th>Date of entry</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <?php foreach ($employees as $employee): ?>
            <tr>
                <td><?= e($employee['FirstName']) ?></td>
                <td><?= e($employee['LastName']) ?></td>
                <td><?= e($employee['Email']) ?></td>
                <td><?= e($employee['DepartmentName']) ?></td>
                <td><?= e($employee['EntryDate']) ?></td>
                <td>
                    <a href="edit.php?id=<?= e((string) $employee['Id']) ?>" class="btn btn-sm btn-outline-secondary">Edit</a>
                    <form method="post" action="delete.php" class="d-inline"
                          onsubmit="return confirm('Are you sure you want to delete <?= e($employee['FirstName'] . ' ' . $employee['LastName']) ?>?');">
                        <input type="hidden" name="id" value="<?= e((string) $employee['Id']) ?>">
                        <button type="submit" class="btn btn-sm btn-outline-danger">Delete</button>
                    </form>
                </td>
            </tr>
        <?php endforeach; ?>
    </tbody>
</table>

<?php require __DIR__ . '/../templates/footer.php'; ?>
