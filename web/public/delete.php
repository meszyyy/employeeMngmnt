<?php

declare(strict_types=1);

require_once __DIR__ . '/../bootstrap.php';

if ($_SERVER['REQUEST_METHOD'] !== 'POST') {
    http_response_code(405);
    exit('Method not allowed.');
}

$id = (int) ($_POST['id'] ?? 0);
$employeeRepository->delete($id);
header('Location: index.php');
exit;
