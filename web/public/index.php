<?php

declare(strict_types=1);

require_once __DIR__ . '/../bootstrap.php';

$employees = $employeeRepository->getAll();

require __DIR__ . '/../templates/header.php';
?>

<div class="app-card">
    <div class="app-card-header d-flex justify-content-between align-items-center">
        <div>
            <h1 class="h5 mb-0">Employees</h1>
            <small class="text-secondary">
                <?= count($employees) === 1 ? '1 employee' : count($employees) . ' employees' ?>
            </small>
        </div>
        <a href="edit.php" class="btn btn-primary">+ New</a>
    </div>

    <div class="table-responsive">
        <table class="table app-table">
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
                        <td class="text-end text-nowrap">
                            <a href="edit.php?id=<?= e((string) $employee['Id']) ?>" class="btn btn-sm btn-outline-secondary">Edit</a>
                            <form method="post" action="delete.php" class="d-inline"
                                  onsubmit="return confirm('Are you sure you want to delete <?= e($employee['FirstName'] . ' ' . $employee['LastName']) ?>?');">
                                <input type="hidden" name="id" value="<?= e((string) $employee['Id']) ?>">
                                <button type="submit" class="btn btn-sm btn-outline-danger">Delete</button>
                            </form>
                        </td>
                    </tr>
                <?php endforeach; ?>

                <?php if ($employees === []): ?>
                    <tr>
                        <td colspan="6" class="text-center text-secondary py-5">
                            No employees yet. Click <strong>+ New</strong> to add the first one.
                        </td>
                    </tr>
                <?php endif; ?>
            </tbody>
        </table>
    </div>
</div>

<?php require __DIR__ . '/../templates/footer.php'; ?>
