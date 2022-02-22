# ALE: ACT Log Extractor

ALE is an open-source tool that takes an [ACT (Advanced Combat Tracker)](https://advancedcombattracker.com/) Final Fantasy XIV `.log` file, extracts text from chat channels of the user's choosing, and then saves the text to a file—without all of the jargon.

![image](https://user-images.githubusercontent.com/63081353/132161494-089de086-5691-4127-a401-30f88feb771c.png)

* # **To be safe, please keep a backup of your log files.**

* **ACT logs do not record [Auto-Translate words](https://ffxiv.fandom.com/wiki/Auto-translator).** However, everything else in the message is still recorded in the ACT log.

* **ACT must be running in order for ACT to save logs.** If ACT is not running during a chat, the chat log **will not be recorded**.

* **ALE does not create ACT logs.** ALE only parses ACT logs. ALE also does not parse or sanitize the game's own log files at this time.

* Screenshots, video recording, and manually copying chat logs in-game are all alternative options to use in addition to ALE for backing up chat logs.

## Usage

1. Check or uncheck which channels to include or exclude.

2. Check or uncheck whether to include channel labels, timestamps, and message spaces.

3. Optionally add or remove name filters by entering a name in the text box and either pressing `Enter` or clicking the `+`, and selecting a name in the list box and pressing `Delete` or clicking the minus `-` button.
   * Only messages from characters with the inputted names will be extracted.
   * You can add or remove character names to the Saved Names list. These names will persist even when the program is closed and reopened. 
   * You can transfer names from the Saved Names list to the Name Filters list by selecting a name and then pressing the single arrow `>` button, or hitting the `→` key. 
   * You can transfer all of your Saved Names to the Name Filters list by pressing the double arrow `>>` button.
   * You can transfer names in the Name Filters list to your Saved Names list by hitting the `←` key.

2. Click on the `Select File and Extract` button.

3. Navigate to and select the log file to extract from.
    * ACT log files are usually found in `AppData\Roaming\Advanced Combat Tracker\FFXIVLogs`.

4. Wait for the log file to be parsed.
    * ACT log files can be very large, so this may take some time. 

5. Click OK on the confirmation window.

6. Select the save destination for the parsed output. 
    * The default filename is `ExtractedLog.txt`. The user may enter a different filename or use a different file extension if they wish.


## Contact

Discord: yesokcool#8548
