# BettySlotAutomation

End-to-end test automation framework for the [Spinberry](https://www.spinberry.com/) slot game platform, covering desktop and mobile browsers.

---

## Tech Stack

| Tool | Version |
|---|---|
| Language | C# / .NET 10 |
| Test Framework | NUnit 4.3.2 |
| Browser Automation | Selenium WebDriver 4.29.0 |
| Driver Management | WebDriverManager 2.17.4 |
| IDE | Visual Studio / Rider |

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Google Chrome, Firefox, or Edge installed locally
- Internet access to reach `https://www.spinberry.com/`

---

## Getting Started

```bash
# Clone the repository
git clone <repo-url>
cd BettySlotAutomation

# Restore dependencies
dotnet restore

# Run all tests
dotnet test

# Run only desktop tests
dotnet test --filter "FullyQualifiedName~Tests.Desktop"

# Run only mobile tests
dotnet test --filter "FullyQualifiedName~Tests.Mobile"

# Run a specific test class
dotnet test --filter "ClassName=IrishWildsTests"

# Run a specific test
dotnet test --filter "Name=BalanceChanges_When_SingleSpinIsPerformed"
```

---

## Project Structure

```
BettySlotAutomation/
│
├── Constants/
│   ├── BrowserConstants.cs        # Timeouts and mobile device name strings
│   └── Games.cs                   # Game name constants
│
├── Core/
│   ├── BasePage.cs                # Abstract base class for all page objects
│   ├── Interfaces/
│   │   ├── IDriver.cs             # Browser driver abstraction
│   │   └── IComponent.cs         # Web element abstraction
│   └── Utilities/
│       ├── DriverAdapter.cs       # IDriver implementation (Selenium WebDriver)
│       ├── ComponentAdapter.cs    # IComponent implementation (wraps IWebElement)
│       └── Logger.cs              # Console/log output utility
│
├── Enums/
│   └── BrowserType.cs             # Supported browsers and devices
│
├── Pages/
│   ├── SpinberryPage/
│   │   ├── SpinberryPage.cs                  # Core actions (Navigate, SelectGame, PlayGame)
│   │   ├── SpinberryPage.Maps.cs             # Desktop element locators
│   │   ├── SpinberryPage.Mobile.Maps.cs      # Mobile element locators
│   │   └── SpinberryPage.Assertions.cs       # Page-level assertions
│   │
│   └── IrishWildsPage/
│       ├── IrishWildsPage.cs                              # Core actions (StartGame, PerformSpin, GetBalance)
│       ├── IrishWildsPage.Maps.cs                         # Main game element locators
│       ├── IrishWildsPage.Assertions.cs                   # Main game assertions
│       ├── IrishWildsPage.AutoPlay.Maps.cs                # AutoPlay panel locators
│       ├── IrishWildsPage.AutoPlay.Actions.cs             # AutoPlay actions (OpenAutoPlay, StartAutoPlay)
│       ├── IrishWildsPage.AutoPlay.Assertions.cs          # AutoPlay assertions
│       ├── IrishWildsPage.HamburgerMenu.Maps.cs           # Hamburger menu locators
│       ├── IrishWildsPage.HamburgerMenu.Actions.cs        # Hamburger menu actions
│       ├── IrishWildsPage.HamburgerMenu.Assertions.cs     # Hamburger menu assertions
│       ├── IrishWildsPage.BuyFeaturePopup.Maps.cs         # Buy Feature popup locators
│       ├── IrishWildsPage.BuyFeaturePopup.Actions.cs      # Buy Feature popup actions
│       └── IrishWildsPage.BuyFeaturePopup.Assertions.cs   # Buy Feature popup assertions
│
├── Tests/
│   ├── BaseTest.cs                # SetUp / TearDown — driver init, navigation, cookie acceptance
│   ├── Desktop/
│   │   ├── SpinberryTests.cs      # Spinberry homepage tests (Chrome)
│   │   └── IrishWildsTests.cs     # Irish Wilds game tests (Chrome)
│   └── Mobile/
│       ├── SpinberryMobileTests.cs      # Spinberry homepage tests (Samsung Galaxy S20 Ultra)
│       └── IrishWildsMobileTests.cs     # Irish Wilds game tests (iPhone 14 Pro Max)
│
└── Urls/
    └── SpinberryUrls.cs           # Base URL constant
```

---

## Architecture

The framework follows the **Page Object Model (POM)** pattern. Each page is split into multiple focused partial class files:

| File suffix | Responsibility |
|---|---|
| `.cs` | Core page actions and state (e.g. `StartGame`, `GetBalance`) |
| `.Maps.cs` | Element locators — one method per element returning `IComponent` |
| `.Actions.cs` | Feature-specific actions (e.g. AutoPlay, HamburgerMenu) |
| `.Assertions.cs` | NUnit assertions grouped by feature area |

### Key abstractions

- **`IDriver`** — wraps Selenium `IWebDriver`. All driver interactions go through this interface, keeping tests decoupled from Selenium.
- **`IComponent`** — wraps Selenium `IWebElement`. Exposes `Text`, `Displayed`, `IsClickable`, `Click`, `TypeText`, and more.
- **`BasePage`** — holds the `IDriver` reference and provides `Navigate()`. All page objects extend this.
- **`BaseTest`** — NUnit base class. Starts the browser, navigates to Spinberry, accepts cookies, and quits the browser after each test.

---

## Supported Browsers & Devices

| Enum value | Browser / Device |
|---|---|
| `Chrome` | Google Chrome (desktop) |
| `ChromeHeadless` | Google Chrome headless |
| `Firefox` | Mozilla Firefox |
| `FirefoxHeadless` | Mozilla Firefox headless |
| `Edge` | Microsoft Edge |
| `EdgeHeadless` | Microsoft Edge headless |
| `Safari` | Safari |
| `ChromeMobileIphone14ProMax` | Chrome emulating iPhone 14 Pro Max |
| `ChromeMobileSamsungS20` | Chrome emulating Samsung Galaxy S20 Ultra |
| `ChromeMobileIpadPro` | Chrome emulating iPad Pro |

---

## Test Coverage

### Spinberry Page — Desktop & Mobile

| Test | Description |
|---|---|
| `SpinberryPageSucceededLoaded_When_NavigatingToHomePage` | Verifies the page title after navigation |
| `SelectedGameSuccessfullyLoaded_When_SelectingGame` | Verifies the Play button appears on game hover |

### Irish Wilds Page — Desktop & Mobile

| Test | Description |
|---|---|
| `DefaultElementsAreDisplayed_When_GamePageIsLoaded` | Attract screen elements are visible |
| `GameElementsAreDisplayed_When_PlayButtonIsClicked` | Game UI elements appear after starting the game |
| `HamburgerMenuElementsAreDisplayed_When_HamburgerMenuIsOpened` | Hamburger menu elements are visible |
| `BuyFeaturePopupElementsAreDisplayed_When_BuyButtonIsClicked` | Buy Feature popup elements are visible |
| `InsufficientFundsLabelIsDisplayedAndBuyButtonIsDisabled_When_PriceExceedsBalance` | Insufficient funds state is handled correctly |
| `BalanceChanges_When_SingleSpinIsPerformed` | Balance updates after one spin |
| `BalanceChanges_When_MultipleSpinsArePerformed` | Balance updates after multiple spins |
| `AutoPlayElementsAreDisplayed_When_AutoPlayIsOpened` | AutoPlay panel elements are visible |
| `BalanceChangesAndSpinsCounterIsDisplayed_When_AutoPlayIsStarted` | Balance changes, spins counter and Stop button appear after AutoPlay starts |

---

## Naming Conventions

- **Classes & methods** — `PascalCase`
- **Private fields** — `_camelCase`
- **Test names** — `WhatHappens_When_Condition`
- **Enum members** — `PascalCase` (e.g. `ChromeMobileIphone14ProMax`)
- **Constants** — `PascalCase` static fields

---

## Adding a New Game

1. Create a folder under `Pages/` (e.g. `Pages/NewGamePage/`)
2. Add partial class files: `NewGamePage.cs`, `NewGamePage.Maps.cs`, `NewGamePage.Assertions.cs`
3. Add feature-specific files as needed (e.g. `NewGamePage.AutoPlay.Maps.cs`)
4. Register the page in `BaseTest.cs`
5. Add the game name constant to `Constants/Games.cs`
6. Create test files under `Tests/Desktop/` and `Tests/Mobile/`
