# ALE: ACT Log Extractor

This program will parse an [ACT (Advanced Combat Tracker)](https://advancedcombattracker.com/) `.log` file you point it to and extract the text from chat channels of your choosing. It will then let you save these chat logs to a file.

![image](https://user-images.githubusercontent.com/63081353/131480265-e6dcd9d8-a43b-4fb4-9ab5-4972d9ec9d5a.png)

It will ignore the rest of the jargon found in ACT log files.

### **To be safe, please keep a backup of your log files.**

## Usage

1. Check or uncheck which channels to include or exclude.

2. Check or uncheck whether to include channel labels and timestamps.

3. Optionally add or remove name filters with the plus `+` or minus `-` buttons.
   * Only messages from characters with the inputted names will be extracted.
   * You can add or remove character names to the Saved Names list. These names will persist even when the program is closed and reopened. You can transfer names from the Saved Names list to the Name Filters list by pressing the arrow in between the two lists.

2. Click on the `Select File and Extract` button.

3. Navigate to and select the log file to extract from.
    * ACT log files are usually found in `AppData\Roaming\Advanced Combat Tracker\FFXIVLogs`.

4. Wait for the log file to be parsed.
    * ACT log files can be very large, so this may take some time. 

5. Click OK on the confirmation window.

6. Select the save destination for the parsed output. 
    * The default filename is `ExtractedLog.txt`. The user may enter a different filename or use a different file extension if they wish.
