# ALE

This program will parse an [ACT (Advanced Combat Tracker)](https://advancedcombattracker.com/) `.log` file you point it to and from it extract the chat from channels you choose. It will then let you save these chat logs to a file.

It will ignore the rest of the jargon found in ACT log files.

To be safe, please keep a backup of your log files.

## Usage

1. Use the checkboxes to select which channels you would like to extract from. For example, if you would like to extract from the "Say" channel, check the box next to Say. If you would like to exclude a channel, uncheck the box next to that channel's label. Some boxes are already checked.

2. Click on the "Select File and Extract" button.

3. Navigate to the log file you wish to extract from. ACT log files are usually found in `AppData\Roaming\Advanced Combat Tracker\FFXIVLogs`.

4. Wait for the log file to be parsed.

5. Click OK on the confirmation window.

6. Select the save destination for the parsed output. The default filename is `ExtractedLog.txt`. The user may enter a different filename or use a different file extension if they wish.

## Channels
* Say
* Shout
* Tell (Sent)
* Tell (Received)
* Party
* Alliance
* Yell
* Custom Emote (Self)
* Custom Emote (Other)
* FC
* All Linkshells
* All Cross-world Linkshells
