<?php

declare(strict_types=1);

require_once __DIR__ . '/../bootstrap.php';

$count = $pdo->query('SELECT COUNT(*) FROM dbo.Employee')->fetchColumn();

echo "Connected. Employees in database: $count";
