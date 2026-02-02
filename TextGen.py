import subprocess
import random
from pathlib import Path

MAX_WORDS = 100

# get the list of words from the dictionary in lower case
WORDS = Path("dic.txt").read_text().lower().split()

# input the amount of words wanted in the text
word_count = 1
try:
    word_count = int(input("Number of Words: "))
    if word_count > MAX_WORDS or word_count < 1:
        word_count = MAX_WORDS
except:
    word_count = MAX_WORDS

# create the text
text = ""
for i in range(word_count):
    text += " "+random.choice(WORDS)

# run the csharp project, pass text as args (as an array of words)
project_dir = Path(__file__).parent
subprocess.run(
    ["dotnet", "run", "--"]+text.split(),
    cwd=str(project_dir),
    check=True
)