<?php

declare(strict_types=1);

require_once __DIR__ . '/../bootstrap.php';

$id = isset($_GET['id']) ? (int) $_GET['id'] : null;

$employee = null;
if ($id !== null) {
    $employee = $employeeRepository->getById($id);
    if ($employee === null) {
        http_response_code(404);
        exit('Employee not found.');
    }
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $data = [
        'FirstName' => trim($_POST['FirstName'] ?? ''),
        'LastName' => trim($_POST['LastName'] ?? ''),
        'Email' => trim($_POST['Email'] ?? ''),
        'DepartmentId' => (int) ($_POST['DepartmentId'] ?? 0),
        'EntryDate' => $_POST['EntryDate'] ?? '',
    ];

    if ($id === null) {
        $employeeRepository->create($data);
    } else {
        $employeeRepository->update($id, $data);
    }

    header('Location: index.php');
    exit;
}

$departments = $employeeRepository->getDepartments();

require __DIR__ . '/../templates/header.php';
?>

<h2 class="h5 mb-3"><?= $employee === null ? 'Add Employee' : 'Edit Employee' ?></h2>

<form method="post" class="bg-white p-4 rounded border" style="max-width: 500px">
    <div class="mb-3">
        <label for="FirstName" class="form-label">First name</label>
        <input type="text" id="FirstName" name="FirstName" class="form-control" maxlength="100"
               value="<?= e($employee['FirstName'] ?? '') ?>">
    </div>

    <div class="mb-3">
        <label for="LastName" class="form-label">Last name</label>
        <input type="text" id="LastName" name="LastName" class="form-control" maxlength="100"
               value="<?= e($employee['LastName'] ?? '') ?>">
    </div>

    <div class="mb-3">
        <label for="Email" class="form-label">E-mail</label>
        <input type="email" id="Email" name="Email" class="form-control" maxlength="320"
               value="<?= e($employee['Email'] ?? '') ?>">
    </div>

    <div class="mb-3">
        <label for="DepartmentId" class="form-label">Department</label>
        <select id="DepartmentId" name="DepartmentId" class="form-select">
            <?php foreach ($departments as $department): ?>
                <option value="<?= e((string) $department['Id']) ?>"
                    <?= ($employee['DepartmentId'] ?? null) == $department['Id'] ? 'selected' : '' ?>>
                    <?= e($department['Name']) ?>
                </option>
            <?php endforeach; ?>
        </select>
    </div>

    <div class="mb-3">
        <label for="EntryDate" class="form-label">Date of entry</label>
        <input type="date" id="EntryDate" name="EntryDate" class="form-control"
               value="<?= e($employee['EntryDate'] ?? '') ?>">
    </div>

    <button type="submit" class="btn btn-primary">Save</button>
    <a href="index.php" class="btn btn-outline-secondary">Cancel</a>
</form>

<?php require __DIR__ . '/../templates/footer.php'; ?>
