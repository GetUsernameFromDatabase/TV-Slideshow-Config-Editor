
# [TV-Slideshow-Config-Editor](https://github.com/GetUsernameFromDatabase/TV-Slideshow-Config-Editor)

This was made to edit TV-Slideshow config file which is a seperate private project on which I was working on.

## Defaults

### Durations
- **Site** - how many ***seconds*** a site is shown *if not givenn an unique duration.*

- **Slide** - how many ***seconds*** a slide is shown *if not givenn an unique duration.*

- **Notification** - how many ***seconds*** a notification is shown *if not givenn an unique duration.*

- - -
```json
"defaults": {
  "durations": {
    "site": 50,
    "slide": 15,
    "notification": 60
  }
}
```

### Show Time
- **Duration** - how many ***seconds*** current time will be shown instead of slides.

- **Interval**- After how many ***slides*** time will be shown.


- - -
```json
"showTime": {
  "duration": 10,
  "interval": 5
},
```

### Sites
- **Duration** - how many ***seconds*** slide will be show. _If url is for slideshow then TV-Slideshow will calculate it automatically_

- **height** - sets the height of the iframe --- since cross-origin iframes can't be manipulated I use javascript to change it's parent div's height and scroll the overflow.
Single column and multicolumn are to take into account different layouts:
_For the site that is intended to be used with TV-Slideshow, information is fed as a single column when **clientWidth** is below 1200px_


- - -
```json
"sites": [
    {
      "url": "./" 
    },
    {
      "url": "https://*",
      "height": {
        "singleColumn": "400%",
        "multiColumn": "110%"
      }
    },
    {
      "url": "https://*",
      "height": "100%",
      "duration": 10
    }
  ],
```

### Notifications
- **Times** - collection of times at which to show notification. *Accepted format* --- ***HH:MM:SS*** or ***HH:MM***. The time can also be a string compatible with JavaScript's [Date](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date/Date). ***ISO 8601** example* - `1995-12-17T03:24:00`

- **Week Days** - Days on which notification will be shown. _Days are in Estonian locale._

- **Audio File** - the location of the audio file

- **Message** - message to be displayed


- - -
```json
"notifications": [
  {
    "schedule": {"times": "11:00", "weekDays": "etkn"},
    "audioFile": "/006Helifailid/Puhkepausid/Esimene.wav",
    "message": "Kohvipaus"
  },
  {
    "schedule": ["12:30", "21:50"],
    "message": "Kuuula, kuidas vaikus..."
  }
]
```