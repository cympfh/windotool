# windotool -- xdotool for Windows Desktop

## Install

TBW.
Executable binary will be released...

## Usage

See

```bash
$ windotool help
```

### key

```bash
$ windotool key Hello  # Types H, e, l, l and o
$ windotool key "^D"   # Ctrl+Shift+D
```

For details for key notation,
please see [.NET document](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys?view=windowsdesktop-6.0).

### mousemove

```bash
$ windotool mousemove {x} {y}  # absolute point
$ windotool mousemove 200 100
```

### click

```bash
$ windotool click {button}  # left is 1, middle is 2 and right is 3.
$ windotool click 1
```

Note: "click" is "mousedown then mouseup".

### mousedown, mouseup

See click.

```bash
# Select (100,100) to (200,200) by leftbutton
$ windotool movemove 100 100
$ windotool mousedown 1
$ windotool movemove 200 200
$ windotool mouseup 1
```

## Todo

- [x] key
    - [x] `-repeat`, `-delay`
- [ ] keydown
- [ ] keyup
- [x] mousemove
- [x] mousedown
- [x] mouseup
- [x] click
    - [x] `-repeat`, `-delay`

## For Windows Developers

Install dotnet,

```bash
$ dotnet run
```
