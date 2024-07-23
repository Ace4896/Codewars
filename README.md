# Codewars Solutions

This repository contains my solutions to various [Codewars](https://www.codewars.com) challenges.

## Requirements

- C\#: .NET 6.0 or above
  - As of 2022-06-22, Codewars uses C# 10.0.
- JavaScript/TypeScript: NodeJS v14.0 or above
  - As of 2022-02-26, Codewars uses NodeJS v14.0 and TypeScript 3.8.
- Python: 3.8 or above
  - As of 2022-02-03, Codewars uses Python 3.8.
- Rust: 1.58 or above
  - As of 2022-02-24, Codewars uses Rust 1.58.
- Visual Basic: .NET 6.0 or above
  - As of 2023-05-22, Codewars uses VB.NET 15.5.

## Usage

This repository needs to be cloned with submodules:

```bash
git clone --recurse-submodules git@github.com:Ace4896/codewars.git
```

For C#, the `Codewars.sln` solution can just be used as normal (preferably with Visual Studio or Rider).

For TypeScript, first run `npm install` in the [`TypeScript`](./TypeScript/) directory, then use `npm test` to run unit tests.

For Python, some additional setup is required:

- First, setup a virtual environment and activate it:
  ```bash
  python -m venv .venv

  source .venv/bin/activate   # Bash
  .venv/Scripts/Activate      # Powershell
  ```
- Then, install the packages from `requirements.txt`:
  ```bash
  pip install -r ./Python/requirements.txt
  ```
  **NOTE**: The build artifacts can be safely removed after installation.

For Rust, the `codewars` crate in the `Rust` directory can be used as normal.

For Visual Basic the `Codewars.VB.sln` can just be used as normal.
