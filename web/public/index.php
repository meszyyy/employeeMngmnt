<?php

declare(strict_types=1);

require_once __DIR__ . '/../bootstrap.php';

$employees = $employeeRepository->getAll();

require __DIR__ . '/../templates/header.php';
?>

<table class="table table-hover bg-white">
    <thead>
        <tr>
            <th>First name</th>
            <th>Last name</th>
            <th>E-mail</th>
            <th>Department</th>
            <th>Date of entry</th>
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
            </tr>
        <?php endforeach; ?>
    </tbody>
</table>

<?php require __DIR__ . '/../templates/footer.php'; ?>
