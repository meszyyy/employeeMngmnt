<?php

declare(strict_types=1);

require_once __DIR__ . '/src/Database.php';

$config = require __DIR__ . '/config.php';
$pdo = Database::connect($config);
