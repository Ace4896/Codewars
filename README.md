# Codewars Solutions

This repository contains my solutions to various [Codewars](https://www.codewars.com) challenges.

## Requirements

- C\#: .NET 6.0 or above
  - As of 2022-01-31, Codewars uses C# 8.0.
- Python: 3.8 or above
  - As of 2022-02-03, Codewars uses Python 3.8.

## Usage

This repository needs to be cloned with submodules:

```bash
git clone --recurse-submodules git@github.com:Ace4896/codewars.git
```

For C#, the `Codewars.sln` solution can just be used as normal (preferably with Visual Studio or Rider).

For Python, some additional setup is required:

- First, setup a virtual environment and activate it:
  ```bash
  python -m venv .venv

  source .venv/bin/activate   # Bash
  .venv/Scripts/Activate      # Powershell
  ```
- Then, install the packages from the `requirements.txt`:
  ```bash
  pip install -r ./Python/requirements.txt
  ```
- Finally, install `codewars-test` from the submodule:
  ```bash
  cd Python/python-test-framework
  python setup.py install
  ```
  The build artifacts can be safely removed after installation.
