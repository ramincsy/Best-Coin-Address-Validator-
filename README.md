# Best Coin Address Validator

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![C# console](https://img.shields.io/badge/C%23-console-512BD4.svg)](Valid-Address/Valid-Address/Valid-Address.csproj)

Paste a cryptocurrency address. This **C# console** app checks it against a dictionary of **regular expressions** (one entry per network) and prints the **first** matching name.

It is a **format check**, not a checksum, not an on-chain lookup, and not a library you reference from other projects.

```bash
dotnet run --project Valid-Address/Valid-Address/Valid-Address.csproj -- 1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa
```

```text
The Bitcoin address '1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa' is valid.
```

## Demo

From the repository root, pass one or more addresses after `--`. The process prints a line per address and exits.

```bash
dotnet run --project Valid-Address/Valid-Address/Valid-Address.csproj -- \
  1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa \
  0x742d35Cc6634C0532925a3b844Bc9e7595f0bEb0 \
  TJYeasRUa3oz3XzGZ9Dw5Xk2XK3D6u1wBf \
  not-an-address
```

| Input | What the app prints |
| --- | --- |
| `1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa` | `The Bitcoin address '…' is valid.` |
| `0x742d35Cc6634C0532925a3b844Bc9e7595f0bEb0` | `The Ethereum address '…' is valid.` |
| `TJYeasRUa3oz3XzGZ9Dw5Xk2XK3D6u1wBf` | `The Tron address '…' is valid.` |
| `not-an-address` | `The address is not valid.` |

`0x` + 40 hex matches **Ethereum** first. Later dictionary entries that use the same shape (THETA, DAI, LINK, Hedera Hashgraph, and the `0x` form of Binance Smart Chain) never win.

Need the prompt instead? Run the same project with no extra arguments, paste an address, press Enter, then any key to check another. Stop with `Ctrl+C`.

```text
Enter the digital currency address to validate:
1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa
The Bitcoin address '1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa' is valid.
Press any key to check another address. Ctrl+C to quit.
```

```bash
dotnet run --project Valid-Address/Valid-Address/Valid-Address.csproj -- --help
```

## Requirements

- A [.NET SDK](https://dotnet.microsoft.com/download) that can build the project
- Project: [`Valid-Address/Valid-Address/Valid-Address.csproj`](Valid-Address/Valid-Address/Valid-Address.csproj)
- Solution: [`Valid-Address/Valid-Address.sln`](Valid-Address/Valid-Address.sln)
- Target framework in the `.csproj`: **`netcoreapp3.1`**

.NET Core 3.1 reached end of support in December 2022. The project sets `RollForward` to `LatestMajor`, so `dotnet run` can use a newer installed runtime (for example .NET 8) when 3.1 is missing. If you prefer a current target, change `<TargetFramework>` to `net8.0` — this program is a single `Program.cs` file with no extra NuGet packages.

You can also open the solution in Visual Studio, Rider, or VS Code with the C# extension.

## What it actually checks

Patterns live in [`Valid-Address/Valid-Address/Program.cs`](Valid-Address/Valid-Address/Program.cs). The names below are the dictionary keys in that file.

| # | Name in code | Typical ticker |
| --- | --- | --- |
| 1 | Bitcoin | BTC |
| 2 | Ethereum | ETH |
| 3 | Litecoin | LTC |
| 4 | NEO | NEO |
| 5 | Polkadot | DOT |
| 6 | Cardano | ADA |
| 7 | Cardano2 | ADA (older Byron-style prefix in this file) |
| 8 | Dogecoin | DOGE |
| 9 | Tron | TRX |
| 10 | XRP | XRP |
| 11 | ICON | ICX |
| 12 | Stellar | XLM |
| 13 | IOTA | IOTA |
| 14 | Atom | ATOM |
| 15 | AVAX | AVAX |
| 16 | SOL | SOL |
| 17 | QTUM | QTUM |
| 18 | THETA | THETA |
| 19 | DAI | DAI |
| 20 | XMR | XMR |
| 21 | LINK | LINK |
| 22 | ALGO | ALGO |
| 23 | XTZ | XTZ |
| 24 | XEM | XEM |
| 25 | KSM | KSM |
| 26 | ONT | ONT |
| 27 | NEAR | NEAR |
| 28 | BAND | BAND |
| 29 | ZIL | ZIL |
| 30 | NANO | NANO |
| 31 | Hedera Hashgraph | HBAR |
| 32 | Bitcoin Cash | BCH |
| 33 | Binance Smart Chain | BSC |

## Limitations (read this before you rely on it)

- A match means “this string looks like one of the regexes,” not “this address is spendable or checksum-correct.”
- Patterns are tested in dictionary order. The **first** hit wins.
- Some regexes are stricter or looser than real-world wallets (for example Litecoin in this file expects an `ltc` / `LTC` prefix; many live Litecoin addresses do not).
- There is no GUI, no API, and no per-coin selector — only the console prompt or command-line arguments.

## Project layout

```
.
├── README.md
├── LICENSE
├── Valid-Address/Valid-Address.sln
└── Valid-Address/Valid-Address/
    ├── Valid-Address.csproj    # netcoreapp3.1 console exe
    └── Program.cs              # regex dictionary + prompt / CLI
```

After you compile, binaries are written under `Valid-Address/Valid-Address/bin/` (gitignored).

## Contributing

Bug reports, tighter patterns, extra networks, and docs fixes are welcome.

1. Open an [issue](https://github.com/ramincsy/Best-Coin-Address-Validator-/issues) for a defect or idea, or start from an existing one.
2. Fork the repo and create a branch.
3. Keep changes focused. If you add a network, put the regex in the same dictionary in `Program.cs` and mention it in this README.
4. Open a pull request that explains what you changed and how you tested it.

Please do not treat a regex match as a security review of an address.

## License

This project is licensed under the [MIT License](LICENSE).

---

## فارسی

برنامهٔ کنسول سی‌شارپ برای **بررسی قالب آدرس** شبکه‌هایی مثل بیت‌کوین، اتریوم و ترون. آدرس را وارد می‌کنید؛ برنامه آن را با چند الگوی regex مقایسه می‌کند و نام **اولین** شبکهٔ مطابق را چاپ می‌کند.

این ابزار **checksum رمزنگاری یا استعلام بلاکچین انجام نمی‌دهد**.

```bash
dotnet run --project Valid-Address/Valid-Address/Valid-Address.csproj -- 1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa
```
