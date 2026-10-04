<?php

declare(strict_types=1);

class EmployeeValidator
{
    public static function validate(array $data): array
    {
        $errors = [];

        if ($data['FirstName'] === '') {
            $errors['FirstName'] = 'First name is required.';
        }

        if ($data['LastName'] === '') {
            $errors['LastName'] = 'Last name is required.';
        }

        if ($data['Email'] === '') {
            $errors['Email'] = 'Email is required.';
        } elseif (!filter_var($data['Email'], FILTER_VALIDATE_EMAIL)) {
            $errors['Email'] = 'Email is not valid.';
        }

        $date = DateTime::createFromFormat('Y-m-d', $data['EntryDate']);
        if ($date === false || $date->format('Y-m-d') !== $data['EntryDate']) {
            $errors['EntryDate'] = 'Entry date is not valid.';
        }

        return $errors;
    }
}
