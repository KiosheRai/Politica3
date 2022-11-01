import {Component, ElementRef, Input, ViewChild} from '@angular/core';
import KeenSlider, {KeenSliderInstance} from "keen-slider"

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: [
    '../../../../node_modules/keen-slider/keen-slider.min.css',
    './slider.component.css'
  ]
})
export class SliderComponent {
  @ViewChild("sliderRef") sliderRef: ElementRef<HTMLElement>

  // @ts-ignore
  slider: KeenSliderInstance
  isLoopOn = false

  @Input() title: string
  @Input() cards: any[]
  @Input() urlImg: string

  ngAfterViewInit() {
    if(this.cards.length > 3){
      this.isLoopOn = false
    }
    this.slider = new KeenSlider(this.sliderRef.nativeElement, {
        loop: this.isLoopOn,
        slides: {
          perView: 3,
          spacing: 32,
        },
        defaultAnimation: {
          duration: 2000
        },
      },
      [
        (slider) => {
          let timeout: any
          let mouseOver = false

          function clearNextTimeout() {
            clearTimeout(timeout)
          }

          function nextTimeout() {
            clearTimeout(timeout)
            if (mouseOver) return
            timeout = setTimeout(() => {
              slider.next()
            }, 2500)
          }

          slider.on("created", () => {
            slider.container.addEventListener("mouseover", () => {
              mouseOver = true
              clearNextTimeout()
            })
            slider.container.addEventListener("mouseout", () => {
              mouseOver = false
              nextTimeout()
            })
            nextTimeout()
          })
          slider.on("dragStarted", clearNextTimeout)
          slider.on("animationEnded", nextTimeout)
          slider.on("updated", nextTimeout)
        },
      ]
    )
  }

  ngOnDestroy() {
    if (this.slider) this.slider.destroy()
  }
}
