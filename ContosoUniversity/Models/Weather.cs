using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Weather
    {
 //       {
	//"resultcode":"200",
	//"reason":"查询成功",
	//"result":{
	//	"sk":{
	//		"temp":"9",
	//		"wind_direction":"东风",
	//		"wind_strength":"2级",
	//		"humidity":"97%",
	//		"time":"10:59"
	//	},
	//	"today":{
	//		"temperature":"9℃~12℃",
	//		"weather":"小雨",
	//		"weather_id":{
	//			"fa":"07",
	//			"fb":"07"
	//		},
	//		"wind":"东风微风",
	//		"week":"星期五",
	//		"city":"河池",
	//		"date_y":"2019年01月11日",
	//		"dressing_index":"较冷",
	//		"dressing_advice":"建议着厚外套加毛衣等服装。年老体弱者宜着大衣、呢外套加羊毛衫。",
	//		"uv_index":"最弱",
	//		"comfort_index":"",
	//		"wash_index":"不宜",
	//		"travel_index":"较不宜",
	//		"exercise_index":"较不宜",
	//		"drying_index":""
	//	},
        [DisplayName("温度")]
        //"temp":"9",
        public string Temperature { get; set; }
        [DisplayName("城市")]
        //"city":河池"
        public string City { get; set; }
        [DisplayName("天气")]
        //"weather":"小雨",
        public string WeatherInfo { get; set; }
        [DisplayName("穿衣指数")]
        //"dressing_advice":"建议着厚外套加毛衣等服装。年老体弱者宜着大衣、呢外套加羊毛衫。",
        public string Wind_strength { get; set; }
        [DisplayName("风向")]
        public string wind { get; set; }
        public string week { get; set; }
    }
}