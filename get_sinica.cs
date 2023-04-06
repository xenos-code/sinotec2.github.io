GIT=/usr/bin/git
gtd=~/GitHubRepos/sinotec2.github.io
TOKEN=$(cat ~/bin/git.token)
today=$(date +%Y%m%d)
rundate=$(date -d "$today +0day" +%Y%m%d)

GRD=( 'grid45'     'grid09'  'grid03' )
i=2
DEV=~/GitHubRepos/sinotec2.github.io/cmaq_forecast/${GRD[$i]}
if [[ $i -eq 2 ]];then
  cd $DEV
  f=D2_PM25.gif
  if [[ -e $f ]];then rm -f $f;fi
  /usr/bin/wget -q https://rcec.sinica.edu.tw/aqrc_webimg/$f
fi
cd $gtd
$GIT pull
$GIT add cmaq_forecast/${GRD[$i]}/*.g*
$GIT commit -m "revised $f $rundate"
$GIT push https://sinotec2:$TOKEN@github.com/sinotec2/sinotec2.github.io.git main >> ~/bat.log
