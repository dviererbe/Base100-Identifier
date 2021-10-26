[![License badge that contains: GPL-3.0-or-later](https://img.shields.io/badge/License-GPL--3.0--or--later-informational)](https://www.gnu.org/licenses/gpl-3.0-standalone.html)

# Base100 Identifier

A free and Open Source .NET library for creating/using Base100 Identifiers.

## Motivation

The library was the result of creating high space-density barcode identfiers for labeling (real world) inventory and archive objects.

There already exists multiple barcode standards, so [there was no need to create one from scretch](https://xkcd.com/927/). Especialy the linear barcode standard [`Code 128`](https://en.wikipedia.org/wiki/Code_128) puts an huge emphasis high space-density.

To understand why base100 identifiers result in the highest space-density for Code128 you need to know how Code128 encoding works:

Code 128 can encode all 128 characters of ASCII, but has only 108 symbols. To represent all 128 ASCII values, it shifts among three code sets (A, B, C). 

Code Set A and B contain characters that are unsuitable for identifiers, because they are not human readable (e.g. [control characters](https://en.wikipedia.org/wiki/Control_character)), could be over-read (e.g. space) or are confusable (e.g `.`, `,`, `;`). That means we would't use the full symbol range of set A and B, which means unused space (WE DON'T WANT THAT!). Also, when Code128 encoded data shifts between the code sets it uses one of the symbol that uses up space (WE DON'T WANT THAT TOO!). 

Code Set C encodes `00` - `99`. That means we get two characters for one Code128 Symbol. This is the reason why Base100 identifiers result in the high space-density, when encoded with Code128.

## License

**Copyright (C) 2021 Dominik Viererbe**

​This program is free software: you can redistribute it and/or modify    
​it under the terms of the GNU General Public License as published by    
​the Free Software Foundation, either version 3 of the License, or    
​(at your option) any later version.    

​This program is distributed in the hope that it will be useful,    
​but WITHOUT ANY WARRANTY; without even the implied warranty of    
​MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the    
​GNU General Public License for more details.

​You should have received a copy of the GNU General Public License    
​along with this program.  If not, see <https://www.gnu.org/licenses/>.    