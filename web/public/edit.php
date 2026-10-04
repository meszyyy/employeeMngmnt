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

$form = $employee ?? [];
$errors = [];

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $data = [
        'FirstName' => trim($_POST['FirstName'] ?? ''),
        'LastName' => trim($_POST['LastName'] ?? ''),
        'Email' => trim($_POST['Email'] ?? ''),
        'DepartmentId' => (int) ($_POST['DepartmentId'] ?? 0),
        'EntryDate' => $_POST['EntryDate'] ?? '',
    ];

    $errors = EmployeeValidator::validate($data);

    if ($errors === []) {
        if ($id === null) {
            $employeeRepository->create($data);
        } else {
            $employeeRepository->update($id, $data);
        }

        header('Location: index.php');
        exit;
    }

    $form = $data;
}

$departments = $employeeRepository->getDepartments();

require __DIR__ . '/../templates/header.php';
?>

<h2 class="h5 mb-3"><?= $employee === null ? 'Add Employee' : 'Edit Employee' ?></h2>

<form method="post" class="bg-white p-4 rounded border" style="max-width: 500px">
    <div class="mb-3">
        <label for="FirstName" class="form-label">First name</label>
        <input type="text" id="FirstName" name="FirstName" maxlength="100"
               class="form-control <?= isset($errors['FirstName']) ? 'is-invalid' : '' ?>"
               value="<?= e($form['FirstName'] ?? '') ?>">
        <?php if (isset($errors['FirstName'])): ?>
            <div class="invalid-feedback"><?= e($errors['FirstName']) ?></div>
        <?php endif; ?>
    </div>

    <div class="mb-3">
        <label for="LastName" class="form-label">Last name</label>
        <input type="text" id="LastName" name="LastName" maxlength="100"
               class="form-control <?= isset($errors['LastName']) ? 'is-invalid' : '' ?>"
               value="<?= e($form['LastName'] ?? '') ?>">
        <?php if (isset($errors['LastName'])): ?>
            <div class="invalid-feedback"><?= e($errors['LastName']) ?></div>
        <?php endif; ?>
    </div>

    <div class="mb-3">
        <label for="Email" class="form-label">E-mail</label>
        <input type="email" id="Email" name="Email" maxlength="320"
               class="form-control <?= isset($errors['Email']) ? 'is-invalid' : '' ?>"
               value="<?= e($form['Email'] ?? '') ?>">
        <?php if (isset($errors['Email'])): ?>
            <div class="invalid-feedback"><?= e($errors['Email']) ?></div>
        <?php endif; ?>
    </div>

    <div class="mb-3">
        <label for="DepartmentId" class="form-label">Department</label>
        <select id="DepartmentId" name="DepartmentId" class="form-select">
            <?php foreach ($departments as $department): ?>
                <option value="<?= e((string) $department['Id']) ?>"
                    <?= ($form['DepartmentId'] ?? null) == $department['Id'] ? 'selected' : '' ?>>
                    <?= e($department['Name']) ?>
                </option>
            <?php endforeach; ?>
        </select>
    </div>

    <div class="mb-3">
        <label for="EntryDate" class="form-label">Date of entry</label>
        <input type="date" id="EntryDate" name="EntryDate"
               class="form-control <?= isset($errors['EntryDate']) ? 'is-invalid' : '' ?>"
               value="<?= e($form['EntryDate'] ?? '') ?>">
        <?php if (isset($errors['EntryDate'])): ?>
            <div class="invalid-feedback"><?= e($errors['EntryDate']) ?></div>
        <?php endif; ?>
    </div>

    <button type="submit" class="btn btn-primary">Save</button>
    <a href="index.php" class="btn btn-outline-secondary">Cancel</a>
</form>

<?php require __DIR__ . '/../templates/footer.php'; ?>
