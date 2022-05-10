# ALE: ACT Log Extractor

ALE is an open-source tool that reads a Final Fantasy XIV [ACT (Advanced Combat Tracker)](https://advancedcombattracker.com/) `.log` file and extracts text from player chat channels without any of the jargon.

![Capture](https://user-images.githubusercontent.com/63081353/164757194-4e5ab6db-b464-4906-bbd7-30eba59c168b.PNG)

* ### **It is *highly* recommended that the user create backups of their original ACT log files before performing any operation on them.**

* **ACT logs do not record [Auto-Translate words](https://ffxiv.fandom.com/wiki/Auto-translator).** However, all other text in a message containing Auto-Translate words will still be recorded in the ACT log.

* **ACT must be running in order for ACT to create logs.** If ACT is not running during a chat, the chat log **will not be recorded**.

* **ALE does not create ACT logs.** ALE only parses ACT logs. ALE also does not parse the game's own log files at this time.

* Screenshots, video recording, and manually copying chat logs in-game are all alternative options to use in addition to ALE for backing up chat logs.

* ALE supports keyboard shortcuts for efficiency: `Enter` to add a name, `Delete` to remove a name, `->` to move a saved name to the name filters list, and `<-` to move a name in the name filters list to the saved names list.

## Usage

1. Check or uncheck which channels to include or exclude.

2. Check or uncheck whether to include channel labels, timestamps, and message spaces.

3. Optionally add or remove name filters by entering a name in the text box and either pressing `Enter` or clicking the `+`, and selecting a name in the list box and pressing `Delete` or clicking the minus `-` button.
   * Only messages from characters with the inputted names will be extracted.
      * Note: When there are active name filters, Tell messages that the user has sent will not show up unless the recipient's name is in the name filters list.
   * You can add or remove character names to the Saved Names list. These names will persist even when the program is closed and reopened. 
   * You can transfer names from the Saved Names list to the Name Filters list by selecting a name and then pressing the single arrow `>` button, or hitting the `→` key. 
   * You can transfer all of your Saved Names to the Name Filters list by pressing the double arrow `>>` button.
   * You can transfer names in the Name Filters list to your Saved Names list by hitting the `←` key.

2. Click on the `Select File and Extract` button.

3. Navigate to and select the log file(s) to extract from.
    * ACT log files are usually found in `AppData\Roaming\Advanced Combat Tracker\FFXIVLogs`.

4. Wait for the log file to be parsed.
    * ACT log files can be very large, so this may take some time. 

5. Click OK on the confirmation window.

6. Select the save destination for the parsed output. 
    * The default filename is `ExtractedLog.txt` and will save in the same directory as ALE by default. The user may enter a different filename or use a different file extension if they wish. 
    * The newly saved file will automatically open in the user's default program for the filetype after saving.
    * There is also a button in ALE to conveniently open ALE's directory.


## Contributing

Feel free to fork this and make pull requests. For any bugs you find or any other problems please use the Issues tab at the top!
