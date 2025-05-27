# Land Miscellaneous API - Sorting Documentation

## Overview

The Land Miscellaneous API endpoints now support sorting functionality. All sorting is performed in ascending order.

## Available Endpoints with Sorting

### 1. Get All Records with Sorting

```
GET /api/landmiscellaneous/all?sortBy={field}
```

### 2. Get Paginated Records with Sorting

```
GET /api/landmiscellaneous/paginated?pageNumber={number}&pageSize={size}&sortBy={field}
```

### 3. Search Records with Sorting

```
GET /api/landmiscellaneous/search?searchTerm={term}&pageNumber={number}&pageSize={size}&sortBy={field}
```

## Sortable Fields

| Field Name                        | API Parameter                    | Description                             |
| --------------------------------- | -------------------------------- | --------------------------------------- |
| ID                                | `id`                             | Primary key                             |
| Master File No                    | `masterfileno`                   | Master file number                      |
| Plan Type                         | `plantype`                       | Type of plan (PP, Cadaster, FVP, etc.)  |
| Plan No                           | `planno`                         | Plan number                             |
| Requesting Authority Reference No | `requestingauthorityreferenceno` | Reference number                        |
| Status                            | `status`                         | Current status (Success, Pending, etc.) |

## Sort Direction

All sorting is performed in **ascending order only**.

## Examples

### Sort by Master File Number

```
GET /api/landmiscellaneous/paginated?sortBy=masterfileno
```

### Sort by Status

```
GET /api/landmiscellaneous/all?sortBy=status
```

### Search with Sorting by Plan Type

```
GET /api/landmiscellaneous/search?searchTerm=PP&sortBy=plantype&pageNumber=1&pageSize=10
```

## Default Behavior

- If no `sortBy` parameter is provided, records are sorted by `Id` in ascending order
- If an invalid `sortBy` field is provided, it defaults to sorting by `Id`
- All sorting is performed in ascending order only

## Response Format

All responses include the sorting parameter in the response:

```json
{
  "Records": [...],
  "TotalCount": 100,
  "PageNumber": 1,
  "PageSize": 10,
  "TotalPages": 10,
  "SortBy": "masterfileno"
}
```

## Backward Compatibility

All existing API calls will continue to work without any changes. The sorting parameter is optional and has sensible defaults.
