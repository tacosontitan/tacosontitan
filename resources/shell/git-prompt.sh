function set_title() {
	PS1='\[\033]0;Git Bash (Hazel | へいぜる)\007\]'
	PS1="$PS1"'\n'
}

function print_user() {
	print "light-yellow" '💃 Hazel | へいぜる '
}

function print_directory() {
	print "white" '📦 \w '
}

function print_git_status() {
	if ! test -z "$WINELOADERNOEXEC"; then
		return
	fi

	GIT_EXEC_PATH="$(git --exec-path 2>/dev/null)"
	COMPLETION_PATH="${GIT_EXEC_PATH%/libexec/git-core}"
	COMPLETION_PATH="${COMPLETION_PATH%/lib/git-core}"
	COMPLETION_PATH="$COMPLETION_PATH/share/git/completion"
	if ! test -f "$COMPLETION_PATH/git-prompt.sh"; then
		return
	fi

	. "$COMPLETION_PATH/git-completion.bash"
	. "$COMPLETION_PATH/git-prompt.sh"
	print "red" "`__git_ps1`"
}

function prompt_user() {
	print "white" '\n🚀 '
}

function print() {
	local specifiedColor=$1
	local text=$2

	# Define colors using variables instead of direct escape codes
	local black='\[\033[30m\]'
	local red='\[\033[31m\]'
	local green='\[\033[32m\]'
	local yellow='\[\033[33m\]'
	local blue='\[\033[34m\]'
	local purple='\[\033[35m\]'
	local cyan='\[\033[36m\]'
	local white='\[\033[37m\]'
	local pink='\[\033[95m\]'
	local light_yellow='\[\033[93m\]'
	local light_green='\[\033[92m\]'
	local default='\[\033[39m\]'

	# Set the color based on the specifiedColor value
	case $specifiedColor in
		"black") PS1+="$black" ;;
		"red") PS1+="$red" ;;
		"green") PS1+="$green" ;;
		"yellow") PS1+="$yellow" ;;
		"blue") PS1+="$blue" ;;
		"purple") PS1+="$purple" ;;
		"cyan") PS1+="$cyan" ;;
		"white") PS1+="$white" ;;
		"pink") PS1+="$pink" ;;
		"light-yellow") PS1+="$light_yellow" ;;
		"light-green") PS1+="$light_green" ;;
		"default") PS1+="$default" ;;
	esac

	PS1+="$text"
}

if test -f ~/.config/git/git-prompt.sh; then
	. ~/.config/git/git-prompt.sh
else
	set_title
	print_user
	print_directory
	print_git_status
	prompt_user
fi

# for detection by MSYS2 SDK's bash.basrc
MSYS2_PS1="$PS1"

# Evaluate all user-specific Bash completion scripts (if any)
if test -z "$WINELOADERNOEXEC"; then
	for c in "$HOME"/bash_completion.d/*.bash; do
		# Handle absence of any scripts (or the folder) gracefully
		test ! -f "$c" || . "$c"
	done
fi
