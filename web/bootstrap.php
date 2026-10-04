<?php

declare(strict_types=1);

require_once __DIR__ . '/src/Database.php';
require_once __DIR__ . '/src/EmployeeRepository.php';
require_once __DIR__ . '/src/EmployeeValidator.php';
require_once __DIR__ . '/src/DuplicateEmailException.php';

$config = require __DIR__ . '/config.php';
$pdo = Database::connect($config);
$employeeRepository = new EmployeeRepository($pdo);

function e(?string $value): string
{
    return htmlspecialchars($value ?? '', ENT_QUOTES, 'UTF-8');
}
