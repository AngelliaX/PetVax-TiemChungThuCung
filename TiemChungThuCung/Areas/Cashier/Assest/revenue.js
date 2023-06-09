﻿let cardColor, headingColor, axisColor, shadeColor, borderColor;

cardColor = config.colors.white;
headingColor = config.colors.headingColor;
axisColor = config.colors.axisColor;
borderColor = config.colors.borderColor;

// Total Revenue Report Chart - Bar Chart
// --------------------------------------------------------------------
const IncomeData23 = [];
const OutcomeData23 = [];


//var Growth = 0;
//for (let i = 1; i <= 12; i++) {
//    Growth += parseFloat(document.getElementById(i.toString()).value);
//}

//Growth = (Growth - 8000) * 100 / 8000;

//for (let month = 1; month <= 12; month++) {
//    Data.push(parseInt(document.getElementById('2').value));
//}

for (let m = 1; m <= 12; m++) {
    IncomeData23.push(parseInt(document.getElementById("income-" + m + "-2023").value));
    OutcomeData23.push(parseInt(document.getElementById("outcome-" + m + "-2023").value));
}



const totalRevenueChartEl = document.querySelector('#totalRevenueChart'),

    totalRevenueChartOptions = {
        series: [
            {
                name: 'Thu',
                data: IncomeData23
            },
            {
                name: 'Chi',
                data: OutcomeData23
            }
        ],

        chart: {
            height: 300,
            stacked: true,
            type: 'bar',
            toolbar: { show: false }
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '33%',
                borderRadius: 12,
                startingShape: 'rounded',
                endingShape: 'rounded'
            }
        },
        colors: [config.colors.primary, config.colors.info],
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'smooth',
            width: 6,
            lineCap: 'round',
            colors: [cardColor]
        },
        legend: {
            show: true,
            horizontalAlign: 'left',
            position: 'top',
            markers: {
                height: 8,
                width: 8,
                radius: 12,
                offsetX: -3
            },
            labels: {
                colors: axisColor
            },
            itemMargin: {
                horizontal: 10
            }
        },
        grid: {
            borderColor: borderColor,
            padding: {
                top: 0,
                bottom: -8,
                left: 20,
                right: 20
            }
        },
        xaxis: {
            categories: ['T1', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'T8', 'T9', 'T10', 'T11', 'T12'],
            labels: {
                style: {
                    fontSize: '13px',
                    colors: axisColor
                }
            },
            axisTicks: {
                show: false
            },
            axisBorder: {
                show: false
            }
        },
        yaxis: {
            labels: {
                style: {
                    fontSize: '13px',
                    colors: axisColor
                }
            }
        },
        responsive: [
            {
                breakpoint: 1700,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '32%'
                        }
                    }
                }
            },
            {
                breakpoint: 1580,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '35%'
                        }
                    }
                }
            },
            {
                breakpoint: 1440,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '42%'
                        }
                    }
                }
            },
            {
                breakpoint: 1300,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '48%'
                        }
                    }
                }
            },
            {
                breakpoint: 1200,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '40%'
                        }
                    }
                }
            },
            {
                breakpoint: 1040,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 11,
                            columnWidth: '48%'
                        }
                    }
                }
            },
            {
                breakpoint: 991,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '30%'
                        }
                    }
                }
            },
            {
                breakpoint: 840,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '35%'
                        }
                    }
                }
            },
            {
                breakpoint: 768,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '28%'
                        }
                    }
                }
            },
            {
                breakpoint: 640,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '32%'
                        }
                    }
                }
            },
            {
                breakpoint: 576,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '37%'
                        }
                    }
                }
            },
            {
                breakpoint: 480,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '45%'
                        }
                    }
                }
            },
            {
                breakpoint: 420,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '52%'
                        }
                    }
                }
            },
            {
                breakpoint: 380,
                options: {
                    plotOptions: {
                        bar: {
                            borderRadius: 10,
                            columnWidth: '60%'
                        }
                    }
                }
            }
        ],
        states: {
            hover: {
                filter: {
                    type: 'none'
                }
            },
            active: {
                filter: {
                    type: 'none'
                }
            }
        }
    };
if (typeof totalRevenueChartEl !== undefined && totalRevenueChartEl !== null) {
    const totalRevenueChart = new ApexCharts(totalRevenueChartEl, totalRevenueChartOptions);
    totalRevenueChart.render();
}

const growthChartEl = document.querySelector('#growthChart'),
    growthChartOptions = {
        series: [Growth.toFixed(2)],
        labels: ['Lợi nhuận'],
        chart: {
            height: 240,
            type: 'radialBar'
        },
        plotOptions: {
            radialBar: {
                size: 150,
                offsetY: 10,
                startAngle: -150,
                endAngle: 150,
                hollow: {
                    size: '55%'
                },
                track: {
                    background: cardColor,
                    strokeWidth: '100%'
                },
                dataLabels: {
                    name: {
                        offsetY: 15,
                        color: headingColor,
                        fontSize: '15px',
                        fontWeight: '600',
                        fontFamily: 'Public Sans'
                    },
                    value: {
                        offsetY: -25,
                        color: headingColor,
                        fontSize: '22px',
                        fontWeight: '500',
                        fontFamily: 'Public Sans'
                    }
                }
            }
        },
        colors: [config.colors.primary],
        fill: {
            type: 'gradient',
            gradient: {
                shade: 'dark',
                shadeIntensity: 0.5,
                gradientToColors: [config.colors.primary],
                inverseColors: true,
                opacityFrom: 1,
                opacityTo: 0.6,
                stops: [30, 70, 100]
            }
        },
        stroke: {
            dashArray: 5
        },
        grid: {
            padding: {
                top: -35,
                bottom: -10
            }
        },
        states: {
            hover: {
                filter: {
                    type: 'none'
                }
            },
            active: {
                filter: {
                    type: 'none'
                }
            }
        }
    };
if (typeof growthChartEl !== undefined && growthChartEl !== null) {
    const growthChart = new ApexCharts(growthChartEl, growthChartOptions);
    growthChart.render();
}