/*
 * animeBlazor.js v1.0.0
 * (c) 2020 Fared Daoud
 * Released under the MIT license
 */

import * as Anime from 'animejs'
import anime from 'animejs'


class Animation {
  id: number;
  animation;
  constructor(id: number, animation) {
    this.id = id;
    this.animation = animation;
  }
}

let activeInstances: Animation[] = [];

export default class animeBlazor {

  static animation(params: any, id: number) {
    var inst = anime(params);
    activeInstances.push(new Animation(id, inst));
  }

  static play(id: number) {
    for (var i = activeInstances.length; i--;) {
      if (activeInstances[i].id == id) {
        activeInstances[i].animation.play();
      }
    }
  }

  static pause(id: number) {
    for (var i = activeInstances.length; i--;) {
      if (activeInstances[i].id == id) {
        activeInstances[i].animation.pause();
      }
    }
  }

  restart(id: number) {
    for (var i = activeInstances.length; i--;) {
      if (activeInstances[i].id == id) {
        activeInstances[i].animation.restart();
      }
    }
  }

  reverse(id: number) {
    for (var i = activeInstances.length; i--;) {
      if (activeInstances[i].id == id) {
        activeInstances[i].animation.reverse();
      }
    }
  }

  remove(targets: string) {
    Anime.remove(targets);
  }
}